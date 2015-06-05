close all;
if ~exist('ArduinoInputsDetects','var')
    [~,~,ArduinoInputsDetects] = xlsread('Arduino Log - InputsDetects.xlsx');
end

LineTypeC = 2;
% SampleNoC = 3;
% IValC = 4;
% QValC = 5;
% SumIC = 6;
% SumQC = 7;
% SampIC = 8;
% SampQC = 9;
% AdjIC = 10;
% AdjQC = 11;
% PrevAdjIC = 12;
% PrevAdjQC = 13;

SnippetSize = 250;
MinCumCuts = 6;
MofN_M = 2;
MofN_N = 8;
MofNBuff = zeros(1,MofN_N);


SampleNoC = 3;
AdjIC = 4;
AdjQC = 5;
IsCutC = 6;
%CurrCutsC = 15;
%RunCutsC = 16;
DispC = 7;
ConfC = 8;

% SumIValsM = 0;
% SumQValsM = 0;

% SamplingErrors = 0;
% InterpolationErrors = 0;
% MeanErrors = 0;
CutErrors = 0;
%CurrCutsErrors = 0;
%RunCutsErrors = 0;
DispErrors = 0;
ConfErrors = 0;

CurrCutsM = 0;
%RunCutsM = 0;

for Idx = 1 : length(ArduinoInputsDetects)-1
    if ~strcmp(ArduinoInputsDetects(Idx, LineTypeC), '#5') || isnan(ArduinoInputsDetects{Idx+1,1})
        continue;
    end
    
    SampleNo = ArduinoInputsDetects{Idx, SampleNoC};

%     if SampleNo == 4251
%     end
%     

    
    %IA = ArduinoInputsDetects{Idx, IValC};
    %QA = ArduinoInputsDetects{Idx, QValC};
    
%     if mod(SampleNo,SnippetSize) == 0
%         fprintf('* Snippet %i, Sample %i\n',mod(SampleNo,SnippetSize), SampleNo);
%     end
    
%     SumIValsM = SumIValsM + IA;
%     SumQValsM = SumQValsM + QA;
    
     if SampleNo < 2
         continue;
     end;
%     
%     SumIA = ArduinoInputsDetects{Idx, SumIC};
%     SumQA = ArduinoInputsDetects{Idx, SumQC};
%     PrevSampIA = ArduinoInputsDetects{Idx-1, SampIC};
%     PrevSampQA = ArduinoInputsDetects{Idx-1, SampQC};
     AdjIA = ArduinoInputsDetects{Idx, AdjIC};
     AdjQA = ArduinoInputsDetects{Idx, AdjQC};
     PrevAdjIA = ArduinoInputsDetects{Idx-1, AdjIC};
     PrevAdjQA = ArduinoInputsDetects{Idx-1, AdjQC};
    
    IsCutA = ArduinoInputsDetects{Idx, IsCutC};
    %CurrCutsA = ArduinoInputsDetects{Idx, CurrCutsC};
    %RunCutsA = ArduinoInputsDetects{Idx, RunCutsC};
    %IsDispA = ArduinoInputsDetects{Idx, DispC};
    %IsConfA = ArduinoInputsDetects{Idx, ConfC};
    
    %PrevAdjIM = ArduinoInputsDetects{Idx-1, AdjIC};
    %PrevAdjQM = ArduinoInputsDetects{Idx-1, AdjQC};
    
    
%     % Check integrity of the data
%     
%     if (PrevSampIA < 0 && PrevSampQA < 0) || (PrevSampIA >= 0 && PrevSampQA >= 0)
%         fprintf('Sampling Error. SampleNo %i\n', SampleNo);
%         SamplingErrors = SamplingErrors + 1;
%     end
%     
%     if PrevSampIA >= 0
%         QValM = floor((ArduinoInputsDetects{Idx-1,QValC} + ArduinoInputsDetects{Idx+1,QValC})/2);
%         if (IA ~= PrevSampIA) || (QA ~= QValM)
%             fprintf('Interpolation Error. SampleNo %i\n', SampleNo);
%             InterpolationErrors = InterpolationErrors + 1;
%         end
%     end
%     
%     if PrevSampQA >= 0
%         IValM = floor((ArduinoInputsDetects{Idx-1,IValC} + ArduinoInputsDetects{Idx+1,IValC})/2);
%         if (QA ~= PrevSampQA) || (IA ~= IValM)
%             fprintf('Interpolation Error. SampleNo %i\n', SampleNo);
%             InterpolationErrors = InterpolationErrors + 1;
%         end
%     end
%     
%     MeanIValsM = floor(SumIValsM / SampleNo);
%     MeanQValsM = floor(SumQValsM / SampleNo);
%     
%     AdjustedIM = IA - MeanIValsM;
%     AdjustedQM = QA - MeanQValsM;
%     
%     if (AdjustedIM ~= AdjIA) || (AdjustedQM ~= AdjQA)
%         fprintf('Mean Calculation Error. SampleNo %i\n', SampleNo);
%         MeanErrors = MeanErrors + 1;
%     end
    
    % Check the cut analysis using previous and current values
    %   We've validated the mean-adjusted sample inputs so we'll just use
    %   them.
            
    PrevAngle = atan2(PrevAdjIA, PrevAdjQA);
    %     if PrevAngle < 0
    %         PrevAngle = PrevAngle + 2*pi;
    %     end
    Angle = atan2(AdjIA, AdjQA);
    %     if Angle < 0
    %         Angle = Angle + 2*pi;
    %     end
    %     Diff1 = mod(abs(Angle - PrevAngle), 2*pi);
    %     if Diff1 > pi
    %         Diff = -(2*pi - Diff1);
    %     else
    %         Diff = Diff1;
    %     end
    %Diff = Angle - PrevAngle;
    
    Diff = angleDiff(PrevAngle, Angle);
    if round(mod(Diff,pi),5) == 0
        Diff = 0;
    end
    
    IsCutM = 0;
    
    % Clockwise: See if going from negative to positive
    if Diff < 0 && PrevAdjIA < 0 && AdjIA > 0
        IsCutM = +1;
    end
    
    % Counter-clockwise: See if going from positive to negative
    if Diff > 0 && PrevAdjIA > 0 && AdjIA < 0
        IsCutM = -1;
    end
    
    if IsCutM ~= IsCutA
        fprintf('Cut Error. Sample No: %i, Arduino: %i; MatLab: %i\n', SampleNo, IsCutA, IsCutM);
        CutErrors = CutErrors + 1;
        
        Cross = (PrevAdjQA * AdjIA) - (PrevAdjIM * AdjQA);
        fprintf('SampNo: %i\n', SampleNo);
        fprintf('Prev (I,Q) Ard: (%i,%i)\n',PrevAdjIA, PrevAdjQA);
        fprintf('Prev (I,Q): (%i,%i); Angle: %2f\n',PrevAdjIA, PrevAdjQA, rad2deg(PrevAngle));
        fprintf('Curr (I,Q): (%i,%i); Angle: %2f\n',AdjIA, AdjQA, rad2deg(Angle));
        fprintf('Diff: %2f, Cross: %i\n\n', rad2deg(Diff), Cross);
        figure;
        plot(PrevAdjQA, PrevAdjIA, '+', AdjQA, AdjIA, '*', 0, 0, 'o');
        MaxX = max(abs(PrevAdjQM),abs(AdjQA)) + 1;
        xlim([-MaxX, MaxX]);
        MaxY = max(abs(PrevAdjIM),abs(AdjIA)) + 1;
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
    
    % We are now on the last sample of the snippet. 
    % Cuts have been validated and summed for the sample.
    % For the Arduino, displacement & confirmation are reported
    %   on the next sample. Hence Idx+1 in the index.
    IsDispA = ArduinoInputsDetects{Idx + 1, DispC};
    IsConfA = ArduinoInputsDetects{Idx + 1, ConfC};

    
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
% fprintf('Sampling Errors: %i\n', SamplingErrors);
% fprintf('Interpolation Errors: %i\n', InterpolationErrors);
% fprintf('Mean Calc Errors: %i\n', MeanErrors);
fprintf('Cut Errors: %i\n', CutErrors);
%fprintf('Curr Cut Errors: %i\n', CurrCutsErrors);
%fprintf('Run Cut Errors: %i\n', RunCutsErrors);
fprintf('Disp Errors: %i\n', DispErrors);
fprintf('Conf Errors: %i\n', ConfErrors);

fprintf('\n');
