%
% Convert binary data vector to I and Q vectors
%
% Arguments: data vector, IQformat
%   I-Q format:
%       0  : I-Q interleaved
%       >0 : blockSize for III ... QQQ format. Typical blocksize is 256

% Returns tuple [I vector, Q vector, number of samples]

function [I,Q,N]=Data2IQ(data,IQformat)
if IQformat > 0
    % Data is in III ... QQQ blocks of IQformat size
    bufferSize = IQformat;
    endIndex = bufferSize;
    startCount = 1;
    endCount = bufferSize;
    while (endCount + bufferSize) <= length(data)
        if startCount == 1
            I = data(startCount:1:endCount);
            startCount = startCount + bufferSize;
            endCount = endCount + bufferSize;
            Q = data(startCount:1:endCount);
        else
            startCount = startCount + bufferSize;
            endCount = endCount + bufferSize;
            I(end+1:endIndex) = data(startCount:1:endCount);
            startCount = startCount + bufferSize;
            endCount = endCount + bufferSize;
            Q(end+1:endIndex) = data(startCount:1:endCount);
        end
        endIndex = endIndex + bufferSize;
    end
else
    % Data is in I-Q interleaved format
    I = data([1:2:length(data)-1]);
    Q = data([2:2:length(data)]);
end

% Calculate the length
N = length(I);