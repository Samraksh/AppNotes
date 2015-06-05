function [ FigHandle ] = fGenerateModulatedOffsetExample( X, IRef, Scale, Freq, PlotPath )

for S = [0 2]
    figure;
    
    figtitle(sprintf('%i/8 Wavelength Offset',S));
    PlotRows = 3;
    PlotCols = 1;
    CurrPlot = 1;
    subplot(PlotRows,PlotCols,CurrPlot);
    CurrPlot = CurrPlot + 1;
    plot(X,IRef,'g');
    ylim([-(Scale*Scale) (Scale*Scale)]);
    title('Reference Wave');
    
    Ret = fCalcRetOffset(X, S, Freq, Scale);
    
    subplot(PlotRows,PlotCols,CurrPlot);
    CurrPlot = CurrPlot + 1;
    plot(X,Ret,'b');
    ylim([-(Scale*Scale) (Scale*Scale)]);
    title(sprintf('Return Wave (%i/8 Wavelength Offset)',S));
    
    IMod = IRef .* Ret;
    IPwr = mean(IMod(~isnan(IMod)));
    if(IPwr < 0 && IPwr > -1e-10) IPwr = 0; end;
    subplot(PlotRows,PlotCols,CurrPlot);
    CurrPlot = CurrPlot + 1;
    plot(X, IMod, 'r');
    ylim([-(Scale*Scale) (Scale*Scale)]);
    title('Modulated Wave');
    legend(sprintf('Power %.2f',IPwr));
    
    filename = sprintf('100 Modulated Offset %i-8 Offset.png',S);
    FigHandle = gcf;
    saveas(FigHandle, strcat(PlotPath,filename));
end

end

