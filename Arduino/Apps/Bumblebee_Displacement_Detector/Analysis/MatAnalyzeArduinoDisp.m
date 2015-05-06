clear all;

cd 'C:\SamrakshGit\AppNotes\Arduino\Apps\Radar Detector\Analysis';
fileName = 'Capture1data.csv';

% Read csv file
%   Assume only numeric data: Sample,I,Q,IsCut,CurrCuts,RunCuts,Disp,Conf
%   Sample: sample number
%   I: I value read
%   Q: Q value read
%   IsCut: -1: counter-clockwise; +1: clockwise; 0: no cut
%   Currcuts: current number of cuts in snippet
%   RunCuts: running sum of cuts
%   Disp: 1 if displacement in snippet else 0
%   Conf: 1 if MofN confirmation else 0

rawCSV = csvread(fileName);
I = rawCSV(:,2);
Q = rawCSV(:,3);
% Adjust I by running mean
sumI = 0;
for r=1:length(I)
    sumI = sumI + I(r);
    I(r) = I(r) - (sumI / r);
end;
% Adjust Q by running mean
sumQ = 0;
for r=1:length(Q)
    sumQ = sumQ + Q(r);
    Q(r) = Q(r) - (sumQ / r);
end;

angle = atan2(I,Q);


% Convert to complex numbers
cplx = Q + (1i * I);

% Get the angle
rot = angle(cplx) / ( 2 * pi);
% Get the diff
df = diff(rot);
% wrap
wrapDf = mod(df + 0.5, 1) - 0.5;
% unwrap
start = wrapDf(1);
unRot = [start; cumsum(wrapDf) + start];

% UnWrap
%Rot = angle(Comp) / (2*pi);
%UnRot = UnWrap(Rot, -0.5,0.5);

dummy = 1;
