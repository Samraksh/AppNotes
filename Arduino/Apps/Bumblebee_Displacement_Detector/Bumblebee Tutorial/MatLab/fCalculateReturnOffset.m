function [ Ret ] = fCalculateReturnOffset( X, Freq, Scale, OffsetAmt, OffsetBase)

% X = time base
% S = Number of 1/8 wavelengths to offset
% Freq = sinc wave frequency

% Calculate offset in time base units
Offset = OffsetAmt * (1/OffsetBase) * (1/Freq);
% Find out how much to truncate at end. Trunc is index of last entry less
% than or equal to Offset
    %Trunc = find (X > Offset,1) - 1; 
% Calculate the offset wave
Ret = sin(2 * pi * Freq * (X + Offset)) * Scale;
% Truncate the end
    %Ret(length(X) - Trunc + 1 : length(X)) = NaN;

end

