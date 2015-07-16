function [ FigHandle ] = fCalculateAngleBetweenPoints( PlotPath, X, Freq, Scale, IRef, QRef )

Index = 0;
IPwr = [];
QPwr = [];
for S = [1 7]
    Ret = fCalculateReturnOffset(X, Freq, Scale, S, 8);

    IMod = IRef .* Ret;
    QMod = QRef .* Ret;

    IPwr = fFixMinusZero(mean(IMod));
    QPwr = fFixMinusZero(mean(QMod));
    Index = Index + 1;
    IAPwr(Index) = IPwr;
    QAPwr(Index) = QPwr;
    
end

figure;
plot(IAPwr, QAPwr,'x');
xlim([-ceil(max(abs(IAPwr))), ceil(max(abs(IAPwr)))]);
ylim([-ceil(max(abs(QAPwr))), ceil(max(abs(QAPwr)))]);
line([0 0], ylim);
line(xlim, [0 0]);
text(IAPwr, QAPwr, {'1','7'}, ...
    'VerticalAlignment','bottom', 'HorizontalAlignment','right');
figtitle('I-Q Plot for Target at 1/8 Wavelength Offsets');
xlabel('In-Phase Power');
ylabel('Quadrature Power');
for i=1:length(IAPwr)
    line([0 IAPwr(i)], [0, QAPwr(i)],'color','r','linestyle','--');
end

filename = sprintf('400 Angle Between Points.png');
FigHandle = gcf;
saveas(FigHandle, strcat(PlotPath,filename));

end

