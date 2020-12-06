%[y,Fs] = audioread('SOMN.mp3');
figure, plot([0:length(y)-1]/Fs,y),xlabel('t'),ylabel('x(t)'),title ('Semnal somn');
for k=1:1:length(y)/Fs
    
    time1(k)=k-1;
    sunet1(k)=y(k*Fs,1); %4.8e+05 = Fs*60 =length(sgn)/(length(sgn)/Fs/60)
end

figure
plot(time1,sunet1);%axis([0 300 -0.0120 0.0120 ]);

z=abs(sunet1);
for k=1:1:length(z)
 
   if z(1,k)>0.0005
       z(1,k)=0;
   end
end

figure, plot(time1,z);axis([ 0 1.8e+04 -0.0060 0.0120]);

caz=2; %%1 sqrt 2 exp

%%%%%%%%%
if caz==1
sgn=z;
for k=1:1:length(sgn)
   if sgn(1,k)>1e-4
       sgn(1,k)=sqrt(sgn(1,k));
   end
   if sgn(1,k)<1e-4
       sgn(1,k)=sgn(1,k);
   end
end
figure,plot(time1,sgn);axis([ 0 1.8e+04 0 0.1]);


figure
capat=301; %length(sgn)/60;
time=zeros(1,capat);
sunet=zeros(1,capat);
for k=1:1:capat
    
    time(1,k)=k-1;
    sunet(1,k)=sgn(1,k*60); 
end
plot(time,sunet);axis([0 300 -0.05 0.1 ]);

x=sunet;
figure,subplot(211),t=time;plot(t,x),axis([0 300 -0.05 0.1 ])
subplot(212),Xf=fft(x);plot(abs(Xf)*2/N),ylabel('Spectrul semnalului x'),axis([0 300 0 0.001 ])
end



%%%%%%%%
if caz==2
sgn=z;
for k=1:1:length(sgn)
   if sgn(1,k)>1e-4
       sgn(1,k)=exp(sgn(1,k));
   end
   if sgn(1,k)<1e-4
       sgn(1,k)=sgn(1,k);
   end
end
figure,plot(time1,sgn); %axis([ 0 1.8e+04 0 0.1]);


figure
capat=301; %length(sgn)/60;
time=zeros(1,capat);
sunet=zeros(1,capat);
for k=1:1:capat
    
    time(1,k)=k-1;
    sunet(1,k)=sgn(1,k*60); 
end
plot(time,sunet); %axis([0 300 -0.05 0.1 ]);

x=sunet;
figure,subplot(211),t=time;plot(t,x)
subplot(212),Xf=fft(x);plot(abs(Xf)*2/N),ylabel('Spectrul semnalului x'),axis([0 300 0 0.1 ]);
end

