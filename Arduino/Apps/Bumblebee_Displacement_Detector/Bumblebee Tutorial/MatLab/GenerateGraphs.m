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

%fGenerateIQPowerValsPlots(X, Freq, Scale, IRef, QRef);

%fGenerateDifferentTargetPowerValues(X, Freq, IRef, QRef);

%fCalculateAngleBetweenPoints(X, Freq, Scale, IRef, QRef);


%fGenerateStationaryObjectExample


Freq = 8;
Duration = 3;
OffsetBase = 8;
X = (0 : XBase * Duration)/XBase;
IRef = sin(2*pi*Freq*X)*Scale;
QRef = cos(2*pi*Freq*X)*Scale;

StatOffsetAmt = 3; %n/8 offset
StatRet = fCalculateReturnOffset(X,Freq,Scale, StatOffsetAmt, OffsetBase);
StatIMod = IRef .* StatRet;
StatQMod = QRef .* StatRet;
StatIPwr = fFixMinusZero(mean(StatIMod));
StatQPwr = fFixMinusZero(mean(StatQMod));

%figure;
%plot (X,StatRet);

%fprintf('\nStatI:\t%.2f\tStatQ:\t%.2f\n', StatIPwr, StatQPwr);

MinOffsetAmt = 0;
MaxOffsetAmt = OffsetBase * Duration;
Index = 0;
TargIPwrH = zeros(MaxOffsetAmt - MinOffsetAmt + 1);
TargQPwrH = zeros(MaxOffsetAmt - MinOffsetAmt + 1);
CmpsIPwrH = zeros(MaxOffsetAmt - MinOffsetAmt + 1);
CmpsQPwrH = zeros(MaxOffsetAmt - MinOffsetAmt + 1);

fprintf('\nStat I\tStat Q\tTarg Off\tOffsetBase\tTarg I\tTarg Q\tCmps I\tCmps Q\tAvg Cmps I\tAvg Cmps Q\tCalc Targ I\tCalc Targ Q\tTarg Angle\tCalc Targ Angle\n');

for TargOffsetAmt = MinOffsetAmt:MaxOffsetAmt
    TargRet = fCalculateReturnOffset(X, Freq, Scale, TargOffsetAmt, OffsetBase);
    TargIMod = IRef .* TargRet;
    TargQMod = QRef .* TargRet;

    CmpsRet = StatRet + TargRet;
    CmpsIMod = IRef .* CmpsRet;
    CmpsQMod = QRef .* CmpsRet;

    
    Index = Index + 1;
    TargIPwrH(Index) = fFixMinusZero(mean(TargIMod));
    TargQPwrH(Index) = fFixMinusZero(mean(TargQMod));

    CmpsIPwrH(Index) = fFixMinusZero(mean(CmpsIMod));
    CmpsQPwrH(Index) = fFixMinusZero(mean(CmpsQMod));
    
    if (Index > OffsetBase)
        CmpsIPwrAvg = mean(CmpsIPwrH(Index-OffsetBase:Index));
        CmpsQPwrAvg = mean(CmpsQPwrH(Index-OffsetBase:Index));
        CalcTargIPwr = CmpsIPwrH(Index) - CmpsIPwrAvg;
        CalcTargQPwr = CmpsQPwrH(Index) - CmpsQPwrAvg;
        TargAngle = rad2deg(atan2(TargIPwrH(Index),TargQPwrH(Index)));
        CmpsAngle = rad2deg(atan2(CalcTargIPwr,CalcTargQPwr));
        CmpsPrint = sprintf('%.2f\t%.2f\t%.2f\t%.2f\t%.2f\t%.2f',CmpsIPwrAvg, CmpsQPwrAvg, CalcTargIPwr, CalcTargQPwr, TargAngle, CmpsAngle);
    else
        CmpsPrint = sprintf('\t\t\t\t\t');
    end
    
    %figure; plot(X,StatRet,'b',X,TargRet,'g',X,CmpsRet,'r');
    %title(sprintf('Stat: Pwr=(%.2f,%.2f), Targ: Pwr=(%.2f,%.2f), Cmps: Pwr=(%.2f,%.2f)',StatIPwr, StatQPwr, TargIPwrH(Index),TargQPwrH(Index),CmpsIPwrH(Index),CmpsQPwrH(Index)));
    
    fprintf('%.2f\t%.2f\t%i\t%i\t%.2f\t%.2f\t%.2f\t%.2f\t%s\n', StatIPwr, StatQPwr, TargOffsetAmt, OffsetBase, TargIPwrH(Index), TargQPwrH(Index), CmpsIPwrH(Index), CmpsQPwrH(Index), CmpsPrint);
    
end


