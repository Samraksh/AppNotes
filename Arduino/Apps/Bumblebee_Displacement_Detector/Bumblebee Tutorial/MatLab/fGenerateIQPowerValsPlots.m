function [ FigHandle ] = fGenerateIQPowerValsPlots(X, Freq, Scale, IRef, QRef)

figure;
figtitle('I-Q Modulation and Power at 1/8 Wavelength Offsets');
MaxS = 8;

IArray = zeros(MaxS+1,1);
QArray = zeros(MaxS+1,1);

fprintf('\nI-Q Power Values for One Wavelength\n');

for S = 0:MaxS
    
    Ret = CalcRetOffset(X, S, Freq, Scale);

    IMod = IRef .* Ret;
    QMod = QRef .* Ret;

    IPwr = fFixMinusZero(mean(IMod));
    QPwr = fFixMinusZero(mean(QMod));
    
    IArray(S+1) = IPwr;
    QArray(S+1) = QPwr;
    
    fprintf('%i,%.2f,%.2f\n', S, IPwr, QPwr);

    subplot(MaxS+2,2,2*S+1);
    plot(X, IMod, 'g');
    ylim([-(Scale*Scale) (Scale*Scale)]);
    title(sprintf('In-Phase, Return Offset = %i/8 Wavelength', S));
    legend(sprintf('Power %.2f',IPwr));
    
    subplot(MaxS+2,2,2*S+2);
    plot(X, QMod, 'r');
    ylim([-(Scale*Scale) (Scale*Scale)]);
    title('Quadrature');
    legend(sprintf('Power %.2f',QPwr));
end

filename = sprintf('200 I-Q Modulation and Power Plots.png');
FigHandle = gcf;
saveas(FigHandle, strcat(PlotPath,filename));


figure;
plot(IArray, QArray,'+-g');
line([0 0], ylim);
line(xlim, [0 0]);
text(IArray, QArray, {'0,8','1','2','3','4','5','6','7',''}, ...
    'VerticalAlignment','bottom', 'HorizontalAlignment','right');
figtitle('I-Q Plot for Target at 1/8 Wavelength Offsets');
ylabel('In-Phase Power');
xlabel('Quadrature Power');

filename = sprintf('200 I-Q Power Circle.png');
FigHandle = gcf;
saveas(FigHandle, strcat(PlotPath,filename));

end

