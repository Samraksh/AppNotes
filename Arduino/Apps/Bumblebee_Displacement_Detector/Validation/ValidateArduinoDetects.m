close all;
if ~exist('ArduinoInputsDetects','var')
    [~,~,ArduinoInputsDetects] = xlsread('Arduino Log - InputsDetects.xlsx');
end

SnippetSize = 250;
MinCumCuts = 6;
MofN_M = 2;
MofN_N = 8;
MofNBuff = zeros(1,MofN_N);

[NRows, NCols] = size(ArduinoInputsDetects);
TagCol = -1;
for I = 1:NCols
    if strcmp(ArduinoInputsDetects(1,I),'#c')
        TagCol = I;
        break;
    end
end

if TagCol < 1
    fprintf('Tag column not found\nTerminating\n');
    return;
end

LineTypeC = TagCol + 0;
SampleNoC = TagCol + 1;
AdjIC = TagCol + 2;
AdjQC = TagCol + 3;
IsCutC = TagCol + 4;
IsDispC = TagCol + 5;
IsConfC = TagCol + 6;

InputCount = 0;
SnippetCount = 0;
CrossAngleErrors = 0;
CutErrors = 0;
DispErrors = 0;
ConfErrors = 0;

CurrCutsM = 0;

for Idx = 1 : NRows - 1
    NextCol1 = ArduinoInputsDetects{Idx+1,1};
    if ~strcmp(ArduinoInputsDetects(Idx, LineTypeC), '#j') || isnan(NextCol1(1))
        continue;
    end
    
    SampleNo = ArduinoInputsDetects{Idx, SampleNoC};
    if SampleNo < 2
        continue;
    end;
    
    InputCount = InputCount + 1;
    
    CurrIA = ArduinoInputsDetects{Idx, AdjIC};
    CurrQA = ArduinoInputsDetects{Idx, AdjQC};
    PrevIA = ArduinoInputsDetects{Idx-1, AdjIC};
    PrevQA = ArduinoInputsDetects{Idx-1, AdjQC};
    
    IsCutA = ArduinoInputsDetects{Idx, IsCutC};
    
    PrevAngle = atan2(PrevIA, PrevQA);
    CurrAngle = atan2(CurrIA, CurrQA);
    
    DiffAngle = angleDiff(PrevAngle, CurrAngle);
    % Ignore the case that one of the points is (0,0)
    if (CurrIA == 0 && CurrQA == 0) || (PrevIA == 0 && PrevQA == 0)
        DiffAngle = 0;
    end
    % Treat angles close to pi as zero
    if round(mod(DiffAngle,pi),5) == 0
        DiffAngle = 0;
    end
    
    % Check that the cross product (used by the mote program) matches the
    % angle difference used here for verification
    
    CrossProduct = (PrevQA * CurrIA) - (PrevIA * CurrQA);
    
    if sign(CrossProduct) ~= sign(DiffAngle)
        CrossAngleErrors = CrossAngleErrors + 1;
    end
    
    % Validate cut
    
    IsCutM = 0;
    
    % Counter clockwise: See if going from negative to positive
    if DiffAngle < 0 && PrevQA > 0 && CurrQA < 0
        IsCutM = +1;
    end
    
    % Clockwise: See if going from positive to negative
    if DiffAngle > 0 && PrevQA < 0 && CurrQA > 0
        IsCutM = -1;
    end
    
    if IsCutM ~= IsCutA
        fprintf('Cut Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, IsCutA, IsCutM);
        CutErrors = CutErrors + 1;
        
        Cross = (PrevQA * CurrIA) - (PrevIA * CurrQA);
        fprintf('SampNo: %i\n', SampleNo);
        fprintf('Prev (I,Q) Ard: (%i,%i)\n',PrevIA, PrevQA);
        fprintf('Prev (I,Q): (%i,%i); Angle: %2f\n',PrevIA, PrevQA, rad2deg(PrevAngle));
        fprintf('Curr (I,Q): (%i,%i); Angle: %2f\n',CurrIA, CurrQA, rad2deg(CurrAngle));
        fprintf('Diff: %2f, Cross: %i\n\n', rad2deg(DiffAngle), Cross);
        figure;
        plot(PrevQA, PrevIA, '+', CurrQA, CurrIA, '*', 0, 0, 'o');
        MaxX = max(abs(PrevAdjQM),abs(CurrQA)) + 1;
        xlim([-MaxX, MaxX]);
        MaxY = max(abs(PrevAdjIM),abs(CurrIA)) + 1;
        ylim([-MaxY, MaxY]);
        
    end
    
    CurrCutsM = CurrCutsM + IsCutA;
    
    %     if SampleNo>=4251 && IsCutA == 1;
    %         fprintf('Sample No: %i, CurrCutsM: %i\n',SampleNo, CurrCutsM);
    %     end;
    
    %     if CurrCutsM ~= CurrCutsA
    %         fprintf('Curr Cuts Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, CurrCutsA, CurrCutsM);
    %         CurrCutsErrors = CurrCutsErrors + 1;
    %     end
    %
    %     RunCutsM = RunCutsM + IsCutM;
    %     if RunCutsM ~= RunCutsA
    %         fprintf('Run Cuts Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, RunCutsA, RunCutsM);
    %         RunCutsErrors = RunCutsErrors + 1;
    %     end
    
    % -------------------------------------------------------------------
    %   Check for displacement & confirmation
    % -------------------------------------------------------------------
    
    if mod(SampleNo,SnippetSize) ~= 0
        continue;
    end
    
    SnippetCount = SnippetCount + 1;
    
    % We are now on the last sample of the snippet.
    % Cuts have been validated and summed for the sample.
    % For the Arduino, displacement & confirmation are reported
    %   on the next sample. Hence Idx+1 in the index.
    IsDispA = ArduinoInputsDetects{Idx + 1, IsDispC};
    IsConfA = ArduinoInputsDetects{Idx + 1, IsConfC};
    
    
    IsDispM = (abs(CurrCutsM) >= MinCumCuts);
    
    % Move the MofN values down
    for I = length(MofNBuff)-1 : -1 : 1
        MofNBuff(I + 1) = MofNBuff(I);
    end
    % Insert the current one
    MofNBuff(1) = IsDispM;
    % Check if sum of displacements is at least MofN_M
    NumDisp = sum(MofNBuff);
    IsConfM = (NumDisp >= MofN_M);
    
    fprintf('\t- Sample No %i, CurrCutsM %i, IsDispA %i, IsDispM %i, IsConfA %i, IsConfM %i\n', SampleNo, CurrCutsM, IsDispA, IsDispM, IsConfA, IsConfM);
    %     if DispA && ConfA
    %     elseif DispA
    %         fprintf('\t- Disp %i\n', CurrCutsM);
    %     elseif ConfA
    %         fprintf('\t- Conf %i\n', ConfA);
    %     end
    
    
    if IsDispM ~= IsDispA
        fprintf('*** Disp Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, IsDispA, IsDispM);
        DispErrors = DispErrors + 1;
    end
    
    if IsConfM ~= IsConfA
        fprintf('*** Conf Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, IsConfA, IsConfM);
        ConfErrors = ConfErrors + 1;
    end
    
    CurrCutsM = 0;
    
end

fprintf('\n');
fprintf('Input Count: %i\n',InputCount);
fprintf('Snippet Count: %i\n',SnippetCount);
fprintf('Cross Product vs. Angle Diff Errors: %i\n',CrossAngleErrors);
fprintf('Cut Errors: %i\n', CutErrors);
fprintf('Disp Errors: %i\n', DispErrors);
fprintf('Conf Errors: %i\n', ConfErrors);

fprintf('\n');
