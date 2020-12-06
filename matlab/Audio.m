
%[y,Fs] = audioread('SOMN.mp3');
figure, plot([0:length(y)-1]/Fs,y),xlabel('t'),ylabel('x(t)'),title ('Semnal somn');
%figure, plot([0:length(y)-1]/Fs,abs(y)),xlabel('t'),ylabel('x(t)'),title ('Semnal somn');

mY=mean(y);
z=abs(y);
for k=1:1:length(z)
   if z(k,1)<-0.001
       z(k,1)=0;
   end
   if z(k,1)>0.001
       z(k,1)=0;
   end
end
z=abs(z);
figure, plot([0:length(z)-1]/Fs,z);axis([ 0 1.8e+04 0 1/100]);

mZ=mean(z);
sgn=z;
for k=1:1:length(sgn)
   if sgn(k,1)>5e-4
       sgn(k,1)=sqrt(sgn(k,1));
   end
   if sgn(k,1)<5e-4
       sgn(k,1)=sgn(k,1);
   end
end
figure,plot([0:length(sgn)-1]/Fs,sgn);axis([ 0 1.8e+04 0 5/100]);


figure
for k=1:1:length(sgn)/Fs/60
    
    time(k)=k-1;
    sunet(k)=sgn(k*4.8e+05,1); %4.8e+05 = Fs*60 =length(sgn)/(length(sgn)/Fs/60)
end
plot(time,sunet);axis([0 300 0 1/1000 ]);

