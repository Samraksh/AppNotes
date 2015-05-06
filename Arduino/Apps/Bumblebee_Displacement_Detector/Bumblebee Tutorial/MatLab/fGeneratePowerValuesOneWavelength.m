function [ ] = fGeneratePowerValuesOneWavelength( X, Freq, Scale, IRef )

%f = figure;
MaxS = 8;
%PowerVals = zeros(MaxS + 1);
%PowerVals = {};
%Offset = 0:MaxS;
%TableVals = [];

fprintf('\nPower Values for One Wavelength\n');

for S = 0:MaxS
    Ret = CalcRetOffset(X, S, Freq, Scale);
    ModulatedReturn = IRef .* Ret;
    IPwr = fFixMinusZero(mean(ModulatedReturn));
    %if(IPwr < 0 && IPwr > -1e-10) IPwr = 0; end;
    fprintf('%i\t%.2f\n',S,IPwr);
    %Offset(S + 1) = S;
    %PowerVals(S + 1) = mean(ModulatedReturn);
    %PowerVals = [PowerVals sprintf('%.2f', mean(ModulatedReturn))];
    %TableVals(S+1,1) = S;
    %TableVals(S+1,2) = sprintf('%.2f', mean(ModulatedReturn));
end
%uitable('Data', [1 2 3], 'ColumnName', {'A', 'B', 'C'}, 'Position', [20 20 500 150]);
%uitable('Data', [Offset' PowerVals'], 'ColumnName', {'Offset 1/8', 'Power'});


end

