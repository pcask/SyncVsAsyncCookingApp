using System.Diagnostics;

namespace AsyncCookingApp
{
    public partial class Form1 : Form
    {
        // Asynchronous olarak gerçekleştirdiğimiz işlemler Main Thread'i kitlemeden arka planda sürdürülmeye devam ederken,
        // bazen bu işlemler uzun zaman alabilir ve bu süre zarfında kaynak tüketimine devam ederler. Lakin bu işlemler her zaman 
        // beklenilmeyebilir, kullanıcı işlemleri iptal etmek isteyebilir, client'ı kapatabilir, işlemleri tekrar başa almak isteyebilir vb.
        // Bu tarz senaryolarda uzun sürebileceğini tahmin ettiğimiz async işlemlerimizi iptal etmek için CancellationToken'lardan 
        // yararlanabiliriz.
        CancellationTokenSource ctsRadio; // Token'ı oluşturacak source nesnemiz
        CancellationToken tokenRadio;     // Source nesnesinin sağladığı token nesnemiz.
        public Form1()
        {
            InitializeComponent();

            ctsRadio = new CancellationTokenSource();
            tokenRadio = ctsRadio.Token;

            btnTurnOffTheRadio.Visible = false;
        }

        // Synchronous (senkron) ilerlediğimiz için ilk olarak radio'dan omlet tarifi dinlenecek ve ardından pişirme
        // adımları çağrılma sırasına göre işletilecektir. Burada pişirme adımlarını biz isteğimiz doğrultusunda bekletiyoruz.
        // CrackTheEggs ve AddTheSalt method'larında sürecin detayları açıklanmıştır.
        private void btnSync_Click(object sender, EventArgs e)
        {
            ResetAllControl();

            timer1.Start();

            ListenTheRecipe();

            var sw = new Stopwatch();
            sw.Start();

            CrackTheEggs();
            AddTheSalt();
            PutThePan();
            TurnOnTheStove();
            PourTheOil();
            HeatThePan();
            BeatTheEggs();
            PourTheBeatenEggs();
            Cook();
            Serve();

            sw.Stop();

            lbActionLogs.Items.Add("");
            LogAction($"\nTotal cooking time = {sw.ElapsedMilliseconds} ms");
        }

        #region Sync Methods
        private void CrackTheEggs()
        {
            // Burada Task nesnesi ile yeni bir thread'e geçiliyor ve Wait method'ı ile mevcut thread (Şuan için UI Thread)
            // bu yeni thread'i beklemeye zorlanıyor. Yani yeni thread işlemini bitirene kadar UI thread kilitleniyor.
            // Buradaki delay işlemi sadece zaman alan bir sürecin işletilmesini simüle ediyor. Eğer işletilecek bir sonraki adım
            // önceki sürecin sonucuna bağlıysa mecburen Wait ile mevcut thread'i bekletmemiz gerekiyor, aksi takdirde
            // mevcut thread kitlenmeden kendi sorumluluğundaki süreçleri işletmeye çalışırken, ihtiyaç duyduğu kaynaklara 
            // ulaşamayacaktır.
            Task.Delay(2000).Wait();

            // 2 saniye sonra aşağıdaki kodlar işletilecektir. Böylelikle tüm süreç synchronous (senkron) olarak gerçekleşir.
            // Yani kodlar çağrım sırasına göre işletilecektir.

            // UI Thread    --------        --------
            // Yeni thread          --------

            Debug.WriteLine($"Thread ID = {Environment.CurrentManagedThreadId}"); // Mevcut thread ID'si basılıyor.
            LogAction("The eggs were cracked.");
            ChangeButtonColor(0);
        }
        private void AddTheSalt()
        {
            Task.Delay(500).Wait();

            // Burada yeni bir thread oluşturuluyor fakat wait ile mevcut thread bekletilmiyor.
            Task myTask = Task.Factory.StartNew(() =>
            {
                // Burada ise yeni bir thread daha oluşturuluyor ve mevcut thread ( myTask ile oluşturulan ) 15 saniye bekletiliyor.
                Task.Delay(15000).Wait(); // Bu işlem myTask'i kitler, UI Thread'i değil.
                Debug.WriteLine($"Thread ID = {Environment.CurrentManagedThreadId}"); // Mevcut thread ID'si basılıyor.
            });

            // Eğer UI thread'i myTask nesnemizin bir sonucuna bağlı olarak çalıştıracak olsaydık yine wait method'ına başvuracaktık.
            // myTask.Wait();

            // UI Thread        ------------------------------------------------------ Bu scope'da UI Thread'i bekleten yok.
            // MyTask thread           --------                           ------------ Bu scope'da MyTask Thread 15 saniye kitlendi.
            // Yeni thread                     -------- 15 saniye --------             15 saniye boyunca işemini yapıyor ve sonlanıyor.


            // Bu scope'da UI Thread'i bekleten hiçbir şey olmadığı için ilk adımda yumurtaların kırılmasıyla tuzun eklenmesi aynı anda
            // olur şeklinde gözlemlenecektir.
            LogAction("The salt was added.");
            ChangeButtonColor(1);
        }
        private void BeatTheEggs()
        {
            Task.Delay(5000).Wait();
            LogAction("The eggs were beaten.");
            ChangeButtonColor(2);
        }
        private void PutThePan()
        {
            Task.Delay(500).Wait();
            LogAction("The pan was put.");
            ChangeButtonColor(3);
        }
        private void TurnOnTheStove()
        {
            Task.Delay(500).Wait();
            LogAction("The stove was turned on.");
            ChangeButtonColor(4);
        }
        private void PourTheOil()
        {
            Task.Delay(500).Wait();
            LogAction("The oil was poured.");
            ChangeButtonColor(5);
        }
        private void HeatThePan()
        {
            Task.Delay(5000).Wait();
            LogAction("The pan was heated.");
            ChangeButtonColor(6);
        }
        private void PourTheBeatenEggs()
        {
            Task.Delay(500).Wait();
            LogAction("The beaten eggs were poured.");
            ChangeButtonColor(7);
        }
        private void Cook()
        {
            Task.Delay(2000).Wait();
            LogAction("The omelet was cooked.");
            ChangeButtonColor(8);
        }
        private void Serve()
        {
            Task.Delay(500).Wait();
            LogAction("The omelet was served.");
            ChangeButtonColor(9);
        }
        #endregion


        // Asynchronous (asenkron) ilerlediğimiz için işlemler, bekletme gerektiren süreçler göz önüne alınarak, sırayla değilde
        // bir işlemden biraz sonra diğer işlemden biraz vb... şeklinde asenkron olarak yütürülecektir.
        // Radio'dan omlet tarifi dinlenirken bir yandan da pişirme adımları gerçekleştirilecektir.
        // CrackTheEggsAsync method'ında ve btnAsync_Click event'inde sürecin detayları açıklanmıştır.
        private async void btnAsync_Click(object sender, EventArgs e)
        {
            timer1.Start();
            ResetAllControl();

            var sw = new Stopwatch();
            sw.Start();

            // Await keyword'ünü neden kullanıyoruz?
            // Await keyword'ü çalıştıracağı task’in işini bitirmesini beklerken task ile ilişkili thread'in non-blocking olarak çalışmasını
            // sağlar. Bu sayede ilgili thread kitlenmeyecek ve diğer işlemleri yürütebilecek veya request'leri karşılayabilecektir.

            
            // Radio dinleme sürecini asenkron yürütüyoruz çünkü burdaki amaç radyodaki talimatları dinlerken
            // eş zamanlı olarak omleti pişirmek. 
            // Peki neden await keyword'ünü kullanmadık?
            // Await'i yürütülen işlemin sonucuna ihtiyaç duyduğumuzda kullanırız. Burada await kullansaydık tüm radyo dinleme sürecimin
            // tamamlanmasını bekle sonra git omletini pişir demiş olurduk.
            ListenTheRecipeAsync(tokenRadio);

            btnTurnOffTheRadio.Visible = true;

            // Bazı işlemler birbirini beklemek zorundayken bazıları beklemeden eş zamanlı olarak da yürütülmelidir.
            // Örneğin tava ısınırken bizde eş zamanlı olarak yumurtaları çırparız, tava 80 dereceye gelsin ondan
            // sonra yumurtaları çırpmalısın diye bir kural yok, bu sadece zaman kaybı olurdu.
            // Diğer yandan da tavanın oçağa konulmasını beklemeliyim ki yağı dökebileyim.

            await PutThePanAsync();         // Tava konmalıki yağ konsun, ısıtma işlemi başlasın.
            PourTheOilAsync();              // Yağ koyma işlemini beklememize gerek yok, tava ısınırken arada yağ konulabilir.
            await TurnOnTheStoveAsync();    // Ocak açılmalıki tava ısınmaya başlasın.

            HeatThePanAsync(); // Tavanın ısınmasını beklememeliyiz, aksine ısınma sırasında diğer işlemleri asenkron olarak yürütmeliyiz.

            await CrackTheEggsAsync(); // Yumurtaların kırılması beklenmeli ki bu işlem sonucunda yumurtalar çırpılabilsin.
            AddTheSaltAsync();         // Tuz eklemeyi beklemesek de olur, çırpılma işlemi sırasında asenkron olarak tuz da eklenebilir.

            await BeatTheEggsAsync()
                .ContinueWith(async _ =>
                {
                    PourTheBeatenEggsAsync();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            // ContinueWith method'ı yeni task oluşturulduğunda bu task UI Thread dışında pool'daki başka bir thread tarafından yürütülebilir.
            // Bu kodların yürütülmesi sırasında UI Thread tarafından oluşturulan bir control'e erişilmeye çalışıldığında
            // 'Cross-thread operation not valid' hatasını alacağız. Çünkü PourTheBeatenEggsAsync method'ı içerisinde
            // loglama işlemi yapılırken ListBox control'üne erişiliyor. Bu hatanın önüne geçmek için;
            // FromCurrentSynchronizationContext() method'ını kullanarak, yeni thread'in işlemlerinin yine UI Thread de yürütülmesini
            // sağlıyoruz, böylelikle ListBox'a erişim işlemini yine UI Thread yapıyor.


            await CookAsync();
            await ServeAsync();

            sw.Stop();

            lbActionLogs.Items.Add("");
            LogAction($"\nTotal cooking time = {sw.ElapsedMilliseconds} ms");
        }

        #region Async Methods
        private async Task CrackTheEggsAsync()
        {
            // Peki UI Thread'i kitlemeden bekletebilir miyiz? Yani bizim sonucuna ulaşmak için zaman gerektiren bir sürecimiz var ve
            // bu süreç işletilirken UI thread kitlenmesin gidip başka işlerini halletsin, ben sürecim tamamlanınca haber veriyim 
            // müsait olan bir thread gelsin ve üretilen sonucu alarak kalan işlemlerde kullansın. Son olarakda UI Thread'e haber
            // vererek Thread Pool'a geri dönsün.
            await Task.Delay(2000);

            // Bekletme işlemi sadece bu scope da geçerlidir ve await keyword'ü ile bekleme başlar. UI Thread artık kitlenmeden
            // sadece aşağıdaki 3 satır için bekleme yapacak ve bu bekleme sırasında diğer işlerle ilgileniyor olacaktır.
            Debug.WriteLine($"Thread ID = {Environment.CurrentManagedThreadId}"); // Mevcut thread ID'si basılıyor.
            LogAction("The eggs were cracked.");
            ChangeButtonColor(0);
        }
        private async Task AddTheSaltAsync()
        {
            await Task.Delay(500);
            LogAction("The salt was added.");
            ChangeButtonColor(1);
        }
        private async Task PutThePanAsync()
        {
            await Task.Delay(500);
            LogAction("The pan was put.");
            ChangeButtonColor(2);
        }
        private async Task TurnOnTheStoveAsync()
        {
            await Task.Delay(500);
            LogAction("The stove was turned on.");
            ChangeButtonColor(3);
        }
        private async Task PourTheOilAsync()
        {
            await Task.Delay(500);
            LogAction("The oil was poured.");
            ChangeButtonColor(4);
        }
        private async Task HeatThePanAsync()
        {
            LogAction("The pan started to be heated.");
            await Task.Delay(5000);
            LogAction("The pan was heated.");
            ChangeButtonColor(5);
        }
        private async Task BeatTheEggsAsync()
        {
            LogAction("The eggs started to be beaten.");
            await Task.Delay(5000);
            LogAction("The eggs were beaten.");
            ChangeButtonColor(6);
        }
        private async Task PourTheBeatenEggsAsync()
        {
            await Task.Delay(500);
            LogAction("The beaten eggs were poured.");
            ChangeButtonColor(7);
        }
        private async Task CookAsync()
        {
            await Task.Delay(2000);
            LogAction("The omelet was cooked.");
            ChangeButtonColor(8);
        }
        private async Task ServeAsync()
        {
            await Task.Delay(500);
            LogAction("The omelet was served.");
            ChangeButtonColor(9);
        }
        #endregion

        private async Task ListenTheRecipeAsync(CancellationToken tokenRadio)
        {
            int s = 8;

            while (s >= 0)
            {
                try
                {
                    // Gönderilen CancellationToken cancel edilmişse anlık hata fırlatır, Task'in yürüttüğü işlemlere devam edilmez,
                    // delay işlemi gerçekleşmeden hata fırlatılacaktır.
                    await Task.Delay(1000, tokenRadio);
                    rtxtRadio.Text += "♫ 𝄞 🎶 ♫ ♪ ";
                    s--;
                }
                catch (OperationCanceledException)
                {
                    LogAction("The radio was turned off.");
                    break;
                }
            }


            // CancellationToken'larımızın iptal edilip edilmediği kontrolünü IsCancellationRequested property'si ile yapabiliriz;
            if (!tokenRadio.IsCancellationRequested)
                rtxtRadio.Text += "\n\nThat's it. Bon appétit :)";

        }
        private void ListenTheRecipe()
        {
            int s = 5;

            while (s >= 0)
            {
                Task.Delay(1000).Wait();

                rtxtRadio.Text += "♫ 𝄞 🎶 ♫ ♪";
                s--;
            }
            rtxtRadio.Text += "\n\nThat's it. Bon appétit :)";
        }
        private void ResetAllControl()
        {
            foreach (Control control in pnlButtons.Controls)
            {
                if (control is Button btn)
                    btn.BackColor = SystemColors.Control;
            }

            pnlButtons.Update();

            lbActionLogs.Items.Clear();
            rtxtRadio.Clear();
        }
        private void ChangeButtonColor(int index)
        {
            Button btn = (Button)pnlButtons.Controls[$"btn{index}"];

            btn.BackColor = Color.Turquoise;

            Debug.WriteLine($"Thread ID = {Environment.CurrentManagedThreadId}");
        }
        private void LogAction(string log)
        {
            // Eğer bir control'e oluşturulduğu thread'den (ki listBox için bu UI Thread) başka bir thread üzerinden erşilmeye çalışılırsa;
            // 'Cross-thread operation not valid' şeklinde bir hata alırız.
            // Böyle bir senaryoda ilgili control için InvokeRequired property'si true dönecektir, biz de bu property'i kontrol ederek
            // control'ün invoke method'ına yapılmasını istediğimiz işleri verebiliriz ve UI Thread'e ne zaman müsait olursan
            // bu işleri yap demiş oluyoruz.
            // Bu ilgili hatayı çözmenin 2. yoluydu.
            //if (lbActionLogs.InvokeRequired)
            //{
            //    lbActionLogs.Invoke(() => LogAction(log));
            //    return;
            //}

            log = $"{DateTime.Now:G} --> {log}";

            lbActionLogs.Items.Add(log);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("T");
        }

        private void btnTurnOffTheRadio_Click(object sender, EventArgs e)
        {
            // Radio dinleme işlemine son vermek için cancellationTokenSource nesnemizin Cancel method'ını çağırmamız yeterli.
            ctsRadio.Cancel();

            // Start Cooking Async butonu ile tekrar pişirme işlemine başladığımızda, radyonun otomatik olarak başlayabilmesi için
            // Cancel edilmemiş yeni bir source nesnesi üzerinden token oluşturuyoruz.
            ctsRadio = new CancellationTokenSource();
            tokenRadio = ctsRadio.Token;
        }
    }
}