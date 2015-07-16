close all;
if ~exist('ArduinoValidationInputs','var')
    [~,~,ArduinoValidationInputs] = xlsread('Arduino Log - Validation Inputs.xlsx');
end

SnippetSize = 250;

[NRows, NCols] = size(ArduinoValidationInputs);
TagCol = -1;
for I = 1:NCols
    if strcmp(ArduinoValidationInputs(1,I),'#c')
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
IValC = TagCol + 2;
QValC = TagCol + 3;
SumIC = TagCol + 4;
SumQC = TagCol + 5;
SampIC = TagCol + 6;
SampQC = TagCol + 7;
AdjIC = TagCol + 8;
AdjQC = TagCol + 9;
PrevAdjIC = TagCol + 10;
PrevAdjQC = TagCol + 11;

SumIValsM = 0;
SumQValsM = 0;

InputCount = 0;
SamplingErrors = 0;
InterpolationErrors = 0;
MeanErrors = 0;
CutErrors = 0;

for Idx = 1 : NRows - 1
    NextCol1 = ArduinoValidationInputs{Idx+1,1};
    if ~strcmp(ArduinoValidationInputs(Idx, LineTypeC), '#i') || isnan(NextCol1(1))
        continue;
    end
    
    InputCount = InputCount + 1;
    
    SampleNo = ArduinoValidationInputs{Idx, SampleNoC};
    IA = ArduinoValidationInputs{Idx, IValC};
    QA = ArduinoValidationInputs{Idx, QValC};
    
    if mod(SampleNo,SnippetSize) == 0
        fprintf('* Snippet %i, Sample %i\n',SampleNo/SnippetSize, SampleNo);
    end
    
    SumIValsM = SumIValsM + IA;
    SumQValsM = SumQValsM + QA;
    
    if SampleNo < 2
        continue;
    end;
    
    SumIA = ArduinoValidationInputs{Idx, SumIC};
    SumQA = ArduinoValidationInputs{Idx, SumQC};
    PrevSampIA = ArduinoValidationInputs{Idx-1, SampIC};
    PrevSampQA = ArduinoValidationInputs{Idx-1, SampQC};
    AdjIA = ArduinoValidationInputs{Idx, AdjIC};
    AdjQA = ArduinoValidationInputs{Idx, AdjQC};
    PrevAdjIA = ArduinoValidationInputs{Idx, PrevAdjIC};
    PrevAdjQA = ArduinoValidationInputs{Idx, PrevAdjQC};
    
    PrevAdjIM = ArduinoValidationInputs{Idx-1, AdjIC};
    PrevAdjQM = ArduinoValidationInputs{Idx-1, AdjQC};
    
    % Check integrity of the data
    
    if (PrevSampIA < 0 && PrevSampQA < 0) || (PrevSampIA >= 0 && PrevSampQA >= 0)
        fprintf('Sampling Error. SampleNo %i\n', SampleNo);
        SamplingErrors = SamplingErrors + 1;
    end
    
    if PrevSampIA >= 0
        QValM = floor((ArduinoValidationInputs{Idx-1,QValC} + ArduinoValidationInputs{Idx+1,QValC})/2);
        if (IA ~= PrevSampIA) || (QA ~= QValM)
            fprintf('Interpolation Error. SampleNo %i\n', SampleNo);
            InterpolationErrors = InterpolationErrors + 1;
        end
    end
    
    if PrevSampQA >= 0
        IValM = floor((ArduinoValidationInputs{Idx-1,IValC} + ArduinoValidationInputs{Idx+1,IValC})/2);
        if (QA ~= PrevSampQA) || (IA ~= IValM)
            fprintf('Interpolation Error. SampleNo %i\n', SampleNo);
            InterpolationErrors = InterpolationErrors + 1;
        end
    end
    
    MeanIValsM = floor(SumIValsM / SampleNo);
    MeanQValsM = floor(SumQValsM / SampleNo);
    
    AdjustedIM = IA - MeanIValsM;
    AdjustedQM = QA - MeanQValsM;
    
    if (AdjustedIM ~= AdjIA) || (AdjustedQM ~= AdjQA)
        fprintf('Mean Calculation Error. SampleNo %i\n', SampleNo);
        MeanErrors = MeanErrors + 1;
    end
end

fprintf('\n');
fprintf('Input Count: %i\n',InputCount);
fprintf('Sampling Errors: %i\n', SamplingErrors);
fprintf('Interpolation Errors: %i\n', InterpolationErrors);
fprintf('Mean Calc Errors: %i\n', MeanErrors);
fprintf('\n');
