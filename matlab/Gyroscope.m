clear all
close all
T = readtable('Gyroscope.csv');

nvm=table2array(T(1:end,1));
Timp=table2array(T(1:end,2))/1000;
X=table2array(T(1:end,3));
Y=table2array(T(1:end,4));
Z=table2array(T(1:end,5));

mX=mean(X);
mY=mean(Y);
mZ=mean(Z);



figure
 subplot(2,1,1);plot(Timp,X);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea X')


for k=1:1:length(Timp)
   if X(k,1)<-0.1
       X(k,1)=mX;
   end
   if X(k,1)>0.1
       X(k,1)=mX;
   end
end
 subplot(2,1,2);plot(Timp,X);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea X')



figure
  subplot(2,1,1);plot(Timp,Y);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Y')
for k=1:1:length(Timp)
   if Y(k,1)<-0.1
       Y(k,1)=mY;
   end
   if Y(k,1)>0.1
       Y(k,1)=mY;
   end
end

  subplot(2,1,2);plot(Timp,Y);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Y')


figure
  subplot(2,1,1);plot(Timp,Z);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Z');
for k=1:1:length(Timp)
   if Z(k,1)<-1.2
       Z(k,1)=mZ;
   end
   if Z(k,1)>1.2
       Z(k,1)=mZ;
   end
end
 subplot(2,1,2);plot(Timp,Z);
title('Achizitionarea datelor Gysocope in timp');
xlabel('Domeniul timp t [sec]');
ylabel('Iesirea Z');