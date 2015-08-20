function Data = fcdReadBin(File)

% ReadBin -- Reads raw data from a data sample file (int16's).

Fid = fopen(File, 'r');
if (Fid < 0)
  disp('Could not open file');
end

Data = fread(Fid, inf, 'uint16');

fclose(Fid);