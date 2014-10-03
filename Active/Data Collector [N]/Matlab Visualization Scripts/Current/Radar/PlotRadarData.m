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
% cleaner: a string that allows special actions. Not case sensitive.
%       M : fix data greater than max (4095 = 2^12)
%       1 : fix data greater than median + 1 std; similarly for 2,3
%       H : make histogram plots

function PlotFig = PlotRadarData(fileNameBare, sampIntervalMilli, IQformat, startTimeSec, endTimeSec, cleaner)
close all;

fileName = [fileNameBare, '.data'];

cleaner = upper(cleaner);

data = ReadBin(fileName);
[I,Q,N]=Data2IQ(data, IQformat);

disp(strcat({'Number of I-Q samples : '},num2str(N)));

disp(strcat({'Number of I values > 4095 : '}, num2str(sum(I>4095))));
disp(strcat({'Number of Q values > 4095 : '}, num2str(sum(Q>4095))));

numIQgt4095 = 0;
foundGt4095 = false;
le4095RangeSt = [];
le4095RangeNd = [];
for i = 1:N
    if I(i) > 4095 || Q(i) > 4095
        numIQgt4095 = numIQgt4095 + 1;
%         if ~foundGt4095
%             le4095RangeNd(i-1) = i-1;
%         end
%         foundGt4095 = true;
%     else
%         if found4095
%             le4095RangeSt = [le4095RangeSt,i];
%             le4095RangeNd = [le4095RangeNd,0];
%         end
%         foundGt4095 = false;
    end
end
% if le4095RangeNd(length(le4095RangeNd),1) == 0
%     le4095RangeNd = N;
% end


disp(strcat({'Number of I-Q samples > 4095 : '}, num2str(numIQgt4095)));
disp(strcat({'Number of unaffected samples : '},num2str(N-numIQgt4095),{', pct : '},num2str((1-numIQgt4095/N)*100)));

if strfind(cleaner,'M')
    disp('* Applying fix for values > 4095');
    % Fix values that exceed the max (2^12-1 = 4095)
    for n = 1:N
        if I(n) > 4095 || Q(n) > 4095
            if n > 1
                I(n) = I(n - 1);
                Q(n) = Q(n - 1);
            else
                I(n) = 0;
                Q(n) = 0;
            end
        end
    end
end

disp(strcat('Std (before std filter if any). I : ',num2str(std(I)),{', Q : '},num2str(std(Q))));
disp(strcat('Median (before std filter if any). I : ',num2str(median(I)),{', Q : '},num2str(median(Q))));

filterStd = 0;
if strfind(cleaner,'1')
    filterStd = 1;
end
if strfind(cleaner,'2')
    filterStd = 2;
end
if strfind(cleaner,'3')
    filterStd = 3;
end
if filterStd > 0
    disp(strcat({'Applying filter of median plus '},num2str(filterStd),{' std'}));
    filterStdI = filterStd * std(I);
    filterStdQ = filterStd * std(Q);
    disp(strcat({'Median + std. I : '},num2str(median(I)+filterStdI),{', Q : '},num2str(median(Q)+filterStdQ)));
    filterI = median(I)+filterStdI;
    filterQ = median(Q)+filterStdQ;
    for n = 1:N
        if I(n) > filterI || Q(n) > filterQ %|| I(n) > 2500 || Q(n) > 2500
            if n > 1
                I(n) = I(n - 1);
                Q(n) = Q(n - 1);
            else
                I(n) = 0;
                Q(n) = 0;
            end
        end
    end
end

disp(strcat({'Median (filtered). I : '},num2str(median(I)),{', Q : '},num2str(median(Q))));
disp(strcat({'Std (filtered). I : '},num2str(std(I)),{', Q : '},num2str(std(Q))));

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

cleanerStr = [' (',cleaner,')'];

if strfind(cleaner,'H')
    figure('name',fileName);
    hist(I,50);
    title(['Radar I',cleanerStr]);
    
    figure('name',fileName);
    hist(Q,50);
    title(['Radar Q',cleanerStr]);
end

PlotFig = figure('name',fileName);
plot(Index,I-median(I),'r'),hold on,grid on  %%% red is I,  green is Q. remember:hong pei lv, hong zai qian
plot(Index,Q-median(Q),'g'),hold off
title(['Radar I and Q',cleanerStr]);

fclose('all');
