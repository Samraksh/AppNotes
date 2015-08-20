%
% Plot Radar Data
% 
% Arguments: file name, sample interval, I-Q format
%
% Sample interval: time between samples, in microseconds
% I-Q format:
%       0  : I-Q interleaved
%       >0 : blockSize for III ... QQQ format. Typical blocksize is 256
% startTimeSec: start time in seconds for the plot
% endTimeSec: end time in seconds for the plot (0 for entire file)

function PlotFig = PlotRadarData(fileNameBare, sampIntervalMilli, IQformat, startTimeSec, endTimeSec)
close all;

fileName = [fileNameBare, '.data'];

data = fctReadBin(fileName);
[I,Q,N] = fctData2IQ(data, IQformat);

disp(strcat({'Number of I-Q samples : '},num2str(N)));

disp(strcat('Std (before std filter if any). I : ',num2str(std(I)),{', Q : '},num2str(std(Q))));
disp(strcat('Median (before std filter if any). I : ',num2str(median(I)),{', Q : '},num2str(median(Q))));

disp(strcat({'Median. I : '},num2str(median(I)),{', Q : '},num2str(median(Q))));
disp(strcat({'Std. I : '},num2str(std(I)),{', Q : '},num2str(std(Q))));

sampRate = 1000000 / sampIntervalMilli; 

if startTimeSec > 0 || endTimeSec > 0
    startTimeSamp = round(startTimeSec * sampRate + 1);
    if endTimeSec == 0
        endTimeSamp = N;
    else
        endTimeSamp = round(endTimeSec * sampRate + 1);
    end
    I1 = I(startTimeSamp : endTimeSamp);
    Q1 = Q(startTimeSamp : endTimeSamp);
    N1 = endTimeSamp - startTimeSamp + 1;
    I = I1; Q = Q1; N = N1;
end

Index = ((1:N)/sampRate) + startTimeSec;

PlotFig = figure('name',fileName);
plot(Index,I-median(I),'r'),hold on,grid on  %%% red is I,  green is Q. remember:hong pei lv, hong zai qian
plot(Index,Q-median(Q),'g'),hold off
title('Radar I and Q');

fclose('all');
