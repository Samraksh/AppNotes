function PlotMicData (fileNameBare, sampIntervalMilli, startTimeSec, endTimeSec)

fileName = [fileNameBare, '.data'];

Fid = fopen(fileName, 'r');
if (Fid < 0)
  disp('Could not open file');
end
Data = fread(Fid, inf, 'uint16');
fclose(Fid);

N = length(Data);

disp(strcat({'Number of samples : '},num2str(N)));

sampRate = 1000000 / sampIntervalMilli;

if startTimeSec > 0 || endTimeSec > 0
    startTimeSamp = round(startTimeSec * sampRate + 1);
    if endTimeSec == 0
        endTimeSamp = N;
    else
        endTimeSamp = round(endTimeSec * sampRate + 1);
    end
    Data1 = Data(startTimeSamp : endTimeSamp);
    N1 = endTimeSamp - startTimeSamp + 1;
    Data = Data1; N = N1;
end

disp(strcat({'Median : '},num2str(median(Data))));
disp(strcat({'Std : '},num2str(std(Data))));

Index = (1:N)/sampRate+ startTimeSec;

figure('name',fileName);
plot(Index,Data,'r*');
title('Microphone');

