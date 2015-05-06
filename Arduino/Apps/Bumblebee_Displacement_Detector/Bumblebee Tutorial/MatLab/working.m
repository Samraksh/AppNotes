for i=0:pi/4:2*pi;
    sinei = sin(i);
    fprintf('%.2f, %.2f\n', rad2deg(i), sinei);
end