function [ FigHandle ] = fGenerateDifferentTargetPowerValues( X, Freq, IRef, QRef )
S = 3;

IPwr = [];
QPwr = [];
Index = 0;
Labels = {};
MaxScale = 2;
for Scale = [.5 .75 1.25 MaxScale]%[1 2 3]
    Ret = CalcRetOffset(X, S, Freq, Scale);
    IMod = IRef .* Ret;
    QMod = QRef .* Ret;

    Index = Index + 1;
    IPwr(Index) = fFixMinusZero(round(mean(IMod),2));
    QPwr(Index) = fFixMinusZero(round(mean(QMod),2));
    Labels = [Labels sprintf('%.2f%%', (Scale / MaxScale * 100))];
end;

figure;
plot(IPwr, QPwr,'x-g');
title(sprintf('Power Values for Different Targets at Offset %i/8 Wavelength',S));
ylabel('In-Phase Power');
xlabel('Quadrature Power');
text(IPwr, QPwr, Labels);

MaxI = ceil(max(abs(IPwr)));
MaxQ = ceil(max(abs(QPwr)));
xlim([-MaxQ,MaxQ]);
ylim([-MaxI,MaxI]);

line([0 0], ylim);
line(xlim, [0 0]);

line([0 IPwr(1)], [0, QPwr(1)],'color','r','linestyle','--');

filename = sprintf('300 Different Target Power Values.png');
FigHandle = gcf;
saveas(FigHandle, strcat(PlotPath,filename));

end

