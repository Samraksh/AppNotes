% Give the length of a radar data file in # samples and time duration

function RadarDataLength(fileNameBare, sampIntervalMilli)

fileName = [fileNameBare,'.data'];

Fid = fopen(fileName, 'r');
if (Fid < 0)
  disp('Could not open file');
end
data = fread(Fid, inf, 'int16');
fclose(Fid);

nSamples = length(data) / 2;

timeMilliSec = nSamples * sampIntervalMilli;

timeTotalSec = timeMilliSec / 1000000;
timeMin = fix(timeTotalSec / 60);
timeSec = round(timeTotalSec - (timeMin * 60));

sprintf('File %s: %d I-Q sample pairs; duration %.0f seconds, %.0f:%f',fileNameBare,nSamples,timeTotalSec,timeMin,timeSec)