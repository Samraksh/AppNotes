function PlotMicData (fileNameBare, sampIntervalMilli, startTimeSec, endTimeSec, cleaner)

cleaner = upper(cleaner);

fileName = [fileNameBare, '.data'];

Fid = fopen(fileName, 'r');
if (Fid < 0)
  disp('Could not open file');
end
Data = fread(Fid, inf, 'uint16');
fclose(Fid);

N = length(Data);

disp(strcat({'Number of samples : '},num2str(N)));

numSamplesgt4095 = sum(Data>4095);

disp(strcat({'Number of samples > 4095 : '}, num2str(numSamplesgt4095)));
disp(strcat({'Number of unaffected samples : '},num2str(N-numSamplesgt4095),{', pct : '},num2str((1-numSamplesgt4095/N)*100)));

if strfind(cleaner,'M')
    disp('* Applying fix for values > 4095');
    % Fix values that exceed the max (2^12-1 = 4095)
    for n = 1:N
        if Data(n) > 4095 
            if n > 1
                Data(n) = Data(n - 1);
            else
                Data(n) = 0;
            end
        end
    end
end

% % Ignore FFFF samples (read as -1)
% if Data(1) < 0 || Data(1) > 4096
%     Data(1) = 0;
% end
% for n = 2:N
%     if Data(n) < 0 || Data(n) > 4096
%         Data(n) = Data(n - 1);
%     end
% end

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

disp(strcat({'Median (filtered) : '},num2str(median(Data))));
disp(strcat({'Std (filtered). : '},num2str(std(Data))));

Index = (1:N)/sampRate+ startTimeSec;

if strfind(cleaner,'H')
    figure('name',fileName);
    hist(Data,50);
    title(['Microphone',' (',cleaner,')']);
end

figure('name',fileName);
plot(Index,Data,'r*');
title(['Microphone',' (',cleaner,')']);

