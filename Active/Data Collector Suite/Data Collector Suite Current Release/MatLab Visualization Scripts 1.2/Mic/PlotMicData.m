function PlotMicData (fileNameBare, sampIntervalMilli)

fileName = [fileNameBare, '.data'];

Fid = fopen(fileName, 'r');
if (Fid < 0)
  disp('Could not open file');
end
Data = fread(Fid, inf, 'int16');
fclose(Fid);

N = length(Data);

% Ignore FFFF samples (read as -1)
if Data(1) < 0 || Data(1) > 4096
    Data(1) = 0;
end
for n = 2:N
    if Data(n) < 0 || Data(n) > 4096
        Data(n) = Data(n - 1);
    end
end

sampRate = 1000000 / sampIntervalMilli;

Index = (1:N)/sampRate;

figure('name',fileName);
plot(Index,Data,'r*');
title('Microphone');
figure(2);
hist(Data,50);
