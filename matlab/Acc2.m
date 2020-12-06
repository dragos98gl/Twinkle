
%% Initilizare
clear all
close all
T = readtable('Accelerometer 2.csv');
Fs=100;

Timp=(table2array(T(1:end,1))-table2array(T(1,1)))/1000;
X=table2array(T(1:end,2));
Y=table2array(T(1:end,3));
Z=table2array(T(1:end,4));

figure, plot(Timp,X);
figure, plot(Timp,Y);
figure, plot(Timp,Z);
 
 
 
 
 %% %X rejectare peste -1250 si sub -1500
 %Pas 1 afisare date initiale
Timp=(table2array(T(1:end,1))-table2array(T(1,1)))/1000;
X=table2array(T(1:end,2));
figure, plot(Timp,X);
%Pas 2 rejectare zgomote si perturbatii exterioare
 for k=1:1:length(X)
   if X(k,1)<-1500
       X(k,1)=-1400;
   end
   if X(k,1)>-1250
       X(k,1)=-1400;
   end
 end
figure, plot(Timp,X); axis([0 3300 -1500 -1250 ]);
CompX=X;
TimeX=Timp;
%Pas 3 aducerea la pragul de zero
for k=1:1:length(X)
   X(k,1)=X(k,1)+1375;
 end
figure, plot(Timp,X); axis([0 3300 -150 150]);
%Pas 4 aducerea la valori absolute
XX=abs(X);
figure, plot(Timp,XX); axis([0 3300 -150 150]);
%Pas 5 esantionarea datelor la 30 de secunde
capat=53*2; %length(sgn)/60/FS;
time=zeros(capat,1);
sunet=zeros(capat,1);
%Date esantionate la 30 de secunde
for k=1:1:capat
    
    time(k,1)=(k-1)/2;
    sunet(k,1)=XX(k*60/2*Fs,1); 
end
figure;plot(time,sunet);axis([0 60 0 100 ]);
%Pas 6 Evidentierea la un interval restrans al datelor esantionate
for k=1:1:length(sunet)
   sunet(k,1)=sunet(k,1)/50;
 end
figure;plot(time,sunet);axis([0 60 0 2 ]);
%Pas 7 Evidentierea zgomotelor 
sgn=sunet;
for k=1:1:length(sgn)
   if sgn(k,1)>0.5
       sgn(k,1)=exp(sgn(k,1));
   end
   if sgn(k,1)<0.5
       sgn(k,1)=sgn(k,1);
   end
end
figure,plot(time,sgn);

zgomot=(sgn-1375)*1;
Tzgomot=time*60;
figure; plot(TimeX,CompX); hold on; plot(Tzgomot,zgomot,'LineWidth',5); axis([0 3300 -1500 -1250 ]);

%% Y rejectare peste -1300 si sub -1600
 %Pas 1 afisare date initiale
Timp=(table2array(T(1:end,1))-table2array(T(1,1)))/1000;
Y=table2array(T(1:end,3));
figure, plot(Timp,Y);
%Pas 2 rejectare zgomote si perturbatii exterioare
for k=1:1:length(Y)
   if Y(k,1)<-1600
       Y(k,1)=-1450;
   end
   if Y(k,1)>-1300
       Y(k,1)=-1450;
   end
 end
figure, plot(Timp,Y); axis([0 3300 -1550 -1300 ]);
CompY=Y;
TimeY=Timp;
%Pas 3 aducerea la pragul de zero
for k=1:1:length(Y)
   Y(k,1)=Y(k,1)+1450;
 end
figure, plot(Timp,Y); axis([0 3300 -200 200]);
%Pas 4 aducerea la valori absolute
YY=abs(Y);
figure, plot(Timp,YY); axis([0 3300 -200 200]);

%Pas 5 esantionarea datelor la 30 de secunde
capat=53*2; %length(sgn)/60/FS;
time=zeros(capat,1);
sunet=zeros(capat,1);
%Date esantionate la 30 de secunde
for k=1:1:capat
    
    time(k,1)=(k-1)/2;
    sunet(k,1)=YY(k*60/2*Fs,1); 
end
figure;plot(time,sunet);axis([0 60 0 150 ]);

%Pas 6 Evidentierea la un interval restrans al datelor esantionate
for k=1:1:length(sunet)
   sunet(k,1)=sunet(k,1)/50;
 end
figure;plot(time,sunet);axis([0 60 0 3 ]);

%Pas 7 Evidentierea zgomotelor 
sgn=sunet;
for k=1:1:length(sgn)
   if sgn(k,1)>0.5
       sgn(k,1)=exp(sgn(k,1));
   end
   if sgn(k,1)<0.5
       sgn(k,1)=sgn(k,1);
   end
end
figure,plot(time,sgn);


zgomot=(sgn-1450)*1;
Tzgomot=time*60;
figure; plot(TimeY,CompY); hold on; plot(Tzgomot,zgomot,'LineWidth',5); axis([0 3300 -1550 -1300 ]);


%% %Z rejectare peste 1.64 si sub 1.62 * 10e4
 %Pas 1 afisare date initiale
Timp=(table2array(T(1:end,1))-table2array(T(1,1)))/1000;
Z=table2array(T(1:end,4));
figure, plot(Timp,Z);
%Pas 2 rejectare zgomote si perturbatii exterioare
for k=1:1:length(Z)
   if Z(k,1)<1.62*10^4;
       Z(k,1)=1.63*10^4;
   end
   if Z(k,1)>1.64*10^4;
       Z(k,1)=1.63*10^4;
   end
 end
figure, plot(Timp,Z); axis([0 3300 1.62*10^4 1.64*10^4; ]);

CompZ=Z;
TimeZ=Timp;
%figure; plot(TimeZ,CompZ);

%Pas 3 aducerea la pragul de zero
for k=1:1:length(Z)
   Z(k,1)=Z(k,1)-1.63*10^4;
 end
figure, plot(Timp,Z); axis([0 3300 -120 120]);
%Pas 4 aducerea la valori absolute
ZZ=abs(Z);
figure, plot(Timp,ZZ); axis([0 3300 -120 120]);

%Pas 5 esantionarea datelor la 30 de secunde
capat=53*2; %length(sgn)/60/FS;
time=zeros(capat,1);
sunet=zeros(capat,1);
%Date esantionate la 30 de secunde
for k=1:1:capat
    
    time(k,1)=(k-1)/2;
    sunet(k,1)=ZZ(k*60/2*Fs,1); 
end
figure;plot(time,sunet);axis([0 60 0 100 ]);

%Pas 6 Evidentierea la un interval restrans al datelor esantionate
for k=1:1:length(sunet)
   sunet(k,1)=sunet(k,1)/25;
 end
figure;plot(time,sunet);axis([0 60 0 2]);

%Pas 7 Evidentierea zgomotelor 
sgn=sunet;
for k=1:1:length(sgn)
   if sgn(k,1)>0.5
       sgn(k,1)=exp(sgn(k,1));
   end
   if sgn(k,1)<0.5
       sgn(k,1)=sgn(k,1);
   end
end
figure,plot(time,sgn);

zgomot=(sgn+1.63*10^4)*1;
Tzgomot=time*60;
figure; plot(TimeZ,CompZ); hold on; plot(Tzgomot,zgomot,'LineWidth',5); axis([0 3300 1.62*10^4 1.64*10^4; ]);

