close all;

%GenModulatedOffsetExample = true;
%GenModulatedOffsetExample = false;

PlotPath = strcat(fileparts(mfilename('fullpath')),'\MatLab Figures\');
XBase = 1000;
X = (0 : XBase)/XBase;
%X = (0 : 10*2*pi)/ 100;
Freq = 4;

Scale = 2;

IRef = sin(2*pi*Freq*X)*Scale;
QRef = cos(2*pi*Freq*X)*Scale;

%fGenerateModulatedOffsetExample(X, IRef, Scale, Freq, PlotPath);

%fGeneratePowerValuesOneWavelength(X, Freq, Scale, IRef);

%fGenerateIQPowerValsPlots(PlotPath, X, Freq, Scale, IRef, QRef);

%fGenerateDifferentTargetPowerValues(PlotPath, X, Freq, IRef, QRef);

%fCalculateAngleBetweenPoints(PlotPath, X, Freq, Scale, IRef, QRef);

fGenerateStationaryObjectExample(XBase, Scale)




