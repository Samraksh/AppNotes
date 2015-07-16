function [] = fGenerateStationaryObjectExample(XBase, Scale)

Freq = 8;
Duration = 10;
OffsetBase = 16;
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

fprintf('\nSample\tStat I\tStat Q\tTarg Off\tOffsetBase\tTarg I\tTarg Q\tCmps I\tCmps Q\tAvg Cmps I\tAvg Cmps Q\tCalc Targ I\tCalc Targ Q\tTarg Angle\tCalc Targ Angle\n');

for Sample = MinOffsetAmt:MaxOffsetAmt
    TargRet = fCalculateReturnOffset(X, Freq, Scale, Sample, OffsetBase);
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
    
%     if (Index > OffsetBase)
%         CmpsIPwrAvg = mean(CmpsIPwrH(Index-OffsetBase:Index));
%         CmpsQPwrAvg = mean(CmpsQPwrH(Index-OffsetBase:Index));
    if (true)
        CmpsIPwrAvg = mean(CmpsIPwrH(1:Index));
        CmpsQPwrAvg = mean(CmpsQPwrH(1:Index));
        CalcTargIPwr = CmpsIPwrH(Index) - CmpsIPwrAvg;
        CalcTargQPwr = CmpsQPwrH(Index) - CmpsQPwrAvg;
        TargAngle = rad2deg(atan2(TargQPwrH(Index),TargIPwrH(Index)));
        CmpsAngle = rad2deg(atan2(CalcTargQPwr,CalcTargIPwr));
        CmpsPrint = sprintf('%.2f\t%.2f\t%.2f\t%.2f\t%.0f\t%.0f',CmpsIPwrAvg, CmpsQPwrAvg, CalcTargIPwr, CalcTargQPwr, TargAngle, CmpsAngle);
    else
        CmpsPrint = sprintf('\t\t\t\t\t\t');
    end
    
    %figure; plot(X,StatRet,'b',X,TargRet,'g',X,CmpsRet,'r');
    %title(sprintf('Stat: Pwr=(%.2f,%.2f), Targ: Pwr=(%.2f,%.2f), Cmps: Pwr=(%.2f,%.2f)',StatIPwr, StatQPwr, TargIPwrH(Index),TargQPwrH(Index),CmpsIPwrH(Index),CmpsQPwrH(Index)));
    
    fprintf('%i\t%.2f\t%.2f\t%i\t%i\t%.2f\t%.2f\t%.2f\t%.2f\t%s\n', Sample, StatIPwr, StatQPwr, Sample, OffsetBase, TargIPwrH(Index), TargQPwrH(Index), CmpsIPwrH(Index), CmpsQPwrH(Index), CmpsPrint);
    
end
