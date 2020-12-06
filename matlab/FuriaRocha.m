[y,Fs] = audioread('SOMN.mp3');
figure, plot([0:length(y)-1]/Fs,y),xlabel('t'),ylabel('x(t)'),title ('Semnal somn');
for k=1:1:length(y)/Fs
    
    time1(k)=k-1;
    sunet1(k)=y(k*Fs,1); %4.8e+05 = Fs*60 =length(sgn)/(length(sgn)/Fs/60)
end
figure
plot(time1,sunet1);

z=sunet1;
for k=1:1:length(z)
 if z(1,k)<-2/1000
       z(1,k)=0;
   end
   if z(1,k)>2/1000
       z(1,k)=0;
   end
end
figure, plot(time1,z);axis([ 0 1.8e+04 -0.0060 0.0120]);


%%Secundele 0->2000
l=z';
P=1; %pornire
N=2000;
n=[P:P+N-1];

x=l(P:P+N-1,1)';

figure,subplot(211),t=[P:P+N-1];plot(t,x)
subplot(212),Xf=fft(x);plot(abs(Xf)*2/N),ylabel('Spectrul semnalului x')

