clear all
close all
T = readtable('Accelerometer.csv');

nvm=table2array(T(1:end,1));
Timp=table2array(T(1:end,2))/1000;
X=table2array(T(1:end,3));
Y=table2array(T(1:end,4));
Z=table2array(T(1:end,5));

mX=mean(X);
mY=mean(Y);
mZ=mean(Z);

figure
 plot(Timp,X);
title('Achizitionarea datelor Accelerometer in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea X')

figure
 plot(Timp,Y);
title('Achizitionarea datelor Accelerometer in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Y')

figure
 plot(Timp,Z);
title('Achizitionarea datelor GAccelerometer in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Z')