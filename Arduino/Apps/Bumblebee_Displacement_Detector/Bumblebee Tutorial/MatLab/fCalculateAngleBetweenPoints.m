function [ FigHandle ] = fCalculateAngleBetweenPoints( X, Freq, Scale, IRef, QRef )

Index = 0;
IPwr = [];
QPwr = [];
for S = [1 7]
    Ret = CalcRetOffset(X, S, Freq, Scale);

    IMod = IRef .* Ret;
    QMod = QRef .* Ret;

    IPwr = fFixMinusZero(mean(IMod));
    QPwr = fFixMinusZero(mean(QMod));
    Index = Index + 1;
    IAPwr(Index) = IPwr;
    QAPwr(Index) = QPwr;
    
end

figure;
plot(IPwr, QPwr,'x');
ylim([-ceil(max(abs(IAPwr))), ceil(max(abs(IAPwr)))]);
xlim([-ceil(max(abs(QAPwr))), ceil(max(abs(QAPwr)))]);
line([0 0], ylim);
line(xlim, [0 0]);
text(IAPwr, QAPwr, {'1','7'}, ...
    'VerticalAlignment','bottom', 'HorizontalAlignment','right');
figtitle('I-Q Plot for Target at 1/8 Wavelength Offsets');
ylabel('In-Phase Power');
xlabel('Quadrature Power');
for i=1:length(IAPwr)
    line([0 IAPwr(i)], [0, QAPwr(i)],'color','r','linestyle','--');
end

filename = sprintf('400 Angle Between Points.png');
FigHandle = gcf;
saveas(FigHandle, strcat(PlotPath,filename));

end

