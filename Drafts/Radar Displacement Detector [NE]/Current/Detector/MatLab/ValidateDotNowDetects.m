close all;

Prefix = 'DotNowSamples';
PathPrefix = strcat('.\',Prefix);

if ~exist('LogData','var')
    [~,~,LogData] = xlsread(strcat(PathPrefix, '.Log.xlsx'));
end

SnippetSize = 250;
MinCumCuts = 6;
MofN_M = 2;
MofN_N = 8;
MofNBuff = zeros(1,MofN_N);

% [~, NCols] = size(LogData);
% TagCol = -1;
% for I = 1:NCols
%     if strcmp(LogData(1,I),'#c')
%         TagCol = I;
%         break;
%     end
% end
% 
% if TagCol < 1
%     fprintf('Tag column not found\nTerminating\n');
%     return;
% end

SampleNoC = 1;
AdjIC = 2;
AdjQC = 3;
IsCutC = 4;
IsDispC = 5;
IsConfC = 6;

InputCount = 0;
SnippetCount = 0;
CrossAngleErrors = 0;
CutErrors = 0;
DispErrors = 0;
ConfErrors = 0;

CurrCutsM = 0;

FirstTime = true;

for Idx = 2 : length(LogData)- 1
    NextCol1 = LogData{Idx+1,1};
    if isnan(NextCol1(1))
        continue;
    end

    SampleNo = LogData{Idx, SampleNoC};
    
    if FirstTime
        % Skip forward to the beginning of a snippet
        if mod(SampleNo,SnippetSize)~=1 % Snippet sample counts are 1-based
            continue;
        end
        % Initialize for comparison with previous sample
        FirstTime = false;
        CurrIA = LogData{Idx, AdjIC};
        CurrQA = LogData{Idx, AdjQC};
        continue;
    end;

    InputCount = InputCount + 1;
      
    PrevIA = CurrIA;
    PrevQA = CurrQA;
    CurrIA = LogData{Idx, AdjIC};
    CurrQA = LogData{Idx, AdjQC};
    
    if isnan(PrevIA)
    end;
    
    IsCutA = LogData{Idx, IsCutC};
    
    PrevAngle = atan2(PrevIA, PrevQA);
    CurrAngle = atan2(CurrIA, CurrQA);
    
    DiffAngle = angleDiff(PrevAngle, CurrAngle);
    % Ignore the case that one of the points is (0,0)
    if (CurrIA == 0 && CurrQA == 0) || (PrevIA == 0 && PrevQA == 0)
        DiffAngle = 0;
    end
    % Treat angles close to pi as zero
    if round(abs(abs(DiffAngle)-pi),5) == 0
        DiffAngle = 0;
    end
%     if round(mod(DiffAngle,pi),5) == 0
%         DiffAngle = 0;
%     end
    
    % Check that the cross product (used by the mote program) matches the
    % angle difference used here for verification
    
    CrossProduct = (PrevQA * CurrIA) - (PrevIA * CurrQA);
    
    if sign(CrossProduct) ~= sign(DiffAngle)
        CrossAngleErrors = CrossAngleErrors + 1;
        fprintf('Cross Product vs Angle Diff Error %i. Sample No: %i\n',CrossAngleErrors,SampleNo);
        fprintf('\tCross: %i, Angle: %i\n', CrossProduct, DiffAngle);
    end
    
    % Validate cut
    
    IsCutM = 0;
    
    % Counter clockwise: See if going from negative to positive
    if DiffAngle < 0 && PrevIA < 0 && CurrIA > 0
        IsCutM = +1;
    end
    
    % Clockwise: See if going from positive to negative
    if DiffAngle > 0 && PrevIA >0 && CurrIA < 0
        IsCutM = -1;
    end
    
    if IsCutM ~= IsCutA
        CutErrors = CutErrors + 1;
        fprintf('Cut Error %i. Sample No: %i, DotNow: %i; MatLab: %i\n', CutErrors, SampleNo, IsCutA, IsCutM);
        
        Cross = (PrevQA * CurrIA) - (PrevIA * CurrQA);
        fprintf('\tSampNo: %i\n', SampleNo);
        %fprintf('Prev (I,Q) Ard: (%i,%i)\n',PrevIA, PrevQA);
        fprintf('\tPrev (I,Q): (%i,%i); Angle: %2f\n',PrevIA, PrevQA, rad2deg(PrevAngle));
        fprintf('\tCurr (I,Q): (%i,%i); Angle: %2f\n',CurrIA, CurrQA, rad2deg(CurrAngle));
        fprintf('\tDiff: %2f, Cross: %i\n\n', rad2deg(DiffAngle), Cross);
%         figure;
%         plot(PrevQA, PrevIA, '+', CurrQA, CurrIA, '*', 0, 0, 'o');
%         MaxX = max(abs(PrevAdjQM),abs(CurrQA)) + 1;
%         xlim([-MaxX, MaxX]);
%         MaxY = max(abs(PrevAdjIM),abs(CurrIA)) + 1;
%         ylim([-MaxY, MaxY]);
    end
    
    CurrCutsM = CurrCutsM + IsCutA;
    
    %     if SampleNo>=4251 && IsCutA == 1;
    %         fprintf('Sample No: %i, CurrCutsM: %i\n',SampleNo, CurrCutsM);
    %     end;
    
    %     if CurrCutsM ~= CurrCutsA
    %         fprintf('Curr Cuts Error. Sample No: %i, DotNow: %i; MatLab: %i\n', SampleNo, CurrCutsA, CurrCutsM);
    %         CurrCutsErrors = CurrCutsErrors + 1;
    %     end
    %
    %     RunCutsM = RunCutsM + IsCutM;
    %     if RunCutsM ~= RunCutsA
    %         fprintf('Run Cuts Error. Sample No: %i, DotNow: %i; MatLab: %i\n', SampleNo, RunCutsA, RunCutsM);
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
    % For the DotNow, displacement & confirmation are reported
    %   on the next sample. Hence Idx+1 in the index.
    IsDispA = LogData{Idx + 1, IsDispC};
    IsConfA = LogData{Idx + 1, IsConfC};
    
    
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
        fprintf('*** Disp Error. Sample No: %i, DotNow: %i; MatLab: %i\n', SampleNo, IsDispA, IsDispM);
        DispErrors = DispErrors + 1;
    end
    
    if IsConfM ~= IsConfA
        fprintf('*** Conf Error. Sample No: %i, DotNow: %i; MatLab: %i\n', SampleNo, IsConfA, IsConfM);
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
