% Used for 2013 data collection
% 

function IQPlotter2013(FileNameBase, SampIntervalMilli)

IFileName = [FileNameBase,'_I.data'];
QFileName = [FileNameBase,'_Q.data'];

iFile = fopen(IFileName, 'r');
qFile = fopen(QFileName, 'r');
iInput = fread(iFile, '*uint16');
qInput = fread(qFile, '*uint16');

for i=1:length(qInput)
    qInput(i) = qInput(i) - 4001;
end;

sampRate = 1000000 / SampIntervalMilli;
iIndex = (1:length(iInput))/sampRate;
qIndex = (1:length(qInput))/sampRate;

figure('name',FileNameBase);
plot(qIndex,qInput,'g');
hold on;
grid on;
plot(iIndex,iInput,'r');

hold off;
title('Radar I and Q');


