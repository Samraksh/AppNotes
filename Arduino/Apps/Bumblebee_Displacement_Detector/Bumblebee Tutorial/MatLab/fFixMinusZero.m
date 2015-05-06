function [ Value ] = fFixMinusZero( Value )
 if(Value < 0 && Value > -1e-10) 
     Value = 0; 
 end;
end

