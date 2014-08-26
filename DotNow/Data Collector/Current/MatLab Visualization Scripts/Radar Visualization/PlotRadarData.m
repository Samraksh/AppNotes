%
% Plot Radar Data
% 
% Arguments: file name, sample rate, I-Q format
%
% I-Q format:
%   0  : I-Q interleaved
%   >0 : blockSize for III ... QQQ format. Typical blocksize is 256
%

function PlotRadarData(fileName, sampIntervalMilli, IQformat)
close all;

data = ReadBin(fileName);
[I,Q,N]=Data2IQ(data, IQformat);

sampRate = 1000000 / sampIntervalMilli; 
Index = ([1:N])/sampRate;
plot(Index,I-median(I),'r'),hold on,grid on  %%% red is I,  green is Q. remember:hong pei lv, hong zai qian
plot(Index,Q-median(Q),'g'),hold off
title('I and Q');

fclose('all');
