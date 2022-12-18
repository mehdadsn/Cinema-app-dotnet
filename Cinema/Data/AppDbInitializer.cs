﻿using CinemaApp.Models;
using System.IO;

namespace CinemaApp.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Users
                if(!context.Users.Any())
                {
                    context.Users.Add(new User()
                    {
                        FullName = "RootAdmin",
                        Email = "root",
                        Password= "root",
                        Role= "Admin",
                        SignUpDate= DateTime.Now,
                    });
                    context.SaveChanges();
                }
                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<CinemaApp.Models.Cinema>()
                    {
                        new CinemaApp.Models.Cinema()
                        {
                            Name = "Cinema Qods Tabriz",
                            LogoUrl = "https://static.cdn.asset.cinematicket.org/media/cache/7c/72/7c72d23bd165934658fc545779cc2c95.webp",
                            About = " خ امام خمینی، نرسیده به چهارراه شریعتی - ایستگاه BRT شریعتی "
                        },
                        new CinemaApp.Models.Cinema()
                        {
                            Name = "Pardis Setare Baran",
                            LogoUrl = "https://static.cdn.asset.cinematicket.org/media/cache/6c/58/6c589a6f7a4c742caf988cea1e083a43.webp",
                            About = "  نصف راه، مجتمع ستاره باران، طبقه سوم - ایستگاه اتوبوس کوچه باغ  "
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Hosein Yari",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/c5/a7/c5a7e28fecd8783c92b877e1ecdcc229.webp",
                            Age = 55,
                            Bio = "حسین یاری بازیگر سینما و تلویزیون اهل ایران است. آغاز فعالیت او در سن ۱۲ سالگی با تئاتر گندم‌های خونین بود و برای اولین بار تجربه بازیگری جلوی دوربین را در سال ۱۳۶۲ با فیلم‌های وارث و سرباز کوچک به‌دست آورد. بازی او در مجموعه تلویزیونی شب دهم در سال ۱۳۸۱ موجب شد او به شدت در بین مردم مشهور شود. او بازیگری در نقش‌های متنوعی مثل فیلم سرعت، دنیای وارونه و بلوغ را تجربه کرده‌است و همچنین در فیلم های سینمایی دیگری همچون پدر آن دیگری، سعادت آباد، میم مثل مادر و مزار شریف نیز حضور داشته است. یاری برنده جایزه سیمرغ بلورین بهترین بازیگر نقش مکمل مرد برای بازی فیلم آخرین مرحله در چهاردهمین جشنواره فیلم فجر شد. او همچنین برای بازی در فیلم سینمایی کتونی سفید برنده جایزه بهترین بازیگر مرد از جشنواره کشتی نوح روسیه شده‌است. "
                        },
                        new Actor()
                        {
                            FullName = "AmirHosein Arman",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/9e/6f/9e6fcb42ecb021fdac0a39b638b1e784.webp",
                            Age = 40,
                            Bio = "امیرحسین آرمان در 4 آبان ماه سال 1361 در تهران متولد شد. وی تحصیلات خود را تا مقطع کارشناسی در رشته طراحی دکوراسیون داخلی ادامه داد. در سال 1381 در دورهای فن بیان مرحوم مصطفی اسکویی شرکت کرد. اولین فعالیت هنری او در سال 1383 و در فیلم سینمایی ازدواج به سبک ایرانی به کارگردانی حسن فتحی است . سپس در سال 1384 در فیلم سینمایی قتل آنلاین به کارگردانی مسعود آب پرور به ایفاء نقش پرداخت. در سال 1386 با بازی در فیلم سینمایی صد سال به این سالها به کارگردانی سامان مقدم، بسیار خوش درخشید. اولین تجربه وی در تلویزیون مربوط به سریال کلاه پهلوی به کارگردانی سید ضیاء الدین دری است که ساخت آن از سال 1383 شروع و در سال 1385 پایان یافت. در سال 1394 با بازی در سریال کیمیا به کارگردانی جواد افشار به اوج محبوبیت خود رسید. از جمله سریال های نمایش خانگی او عبارت است از: مسابقه 13 شمالی به کارگردانی علیرضا امینی، ممنوعه به کارگردانی امیر پور کیان، مانکن به کارگردانی حسین سهیلی زاده. "
                        },
                        new Actor()
                        {
                            FullName = "Pejman Jamshidi",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/e3/52/e3528e38338b39ea6342f2cab8f647b3.webp",
                            Age = 46,
                            Bio = "پژمان جمشیدی، بازیکن سابق فوتبال و بازیگر سینما ،تلویزیون وتئاتر در ۲۰ شهریور ۱۳۵۶در تهران متولد شد. او به دلیل فعالیت در فوتبال، تحصیل در رشته مهندسی عمران را ناتمام رها کرد. جمشیدی، فوتبال را به‌طور حرفه‌ای از نوجوانی و در تیم نوجوانان باشگاه دارایی تهران فراگرفت و در سال ۱۳۷۴ به عضویت تیم ملی نوجوانان در آمد. بازی او در باشگاه سایپا تهران مورد توجه قرار گرفت و از همان‌جا به تیم ملی جوانان و تیم ملی امید ایران ملحق شد. او در سال 1379 به باشگاه پرسپولیس رفت و حدود 100 بازی در طی 5 سال برای پرسپولیس انجام داد واز بازیکنان سرعتی و تکنیکی پرسپولیس محسوب می شد. وی برای اولین بار در مجموعه تلویزیونی ساختمان پزشکان به کارگردانی سروش صحت جلوی دوربین رفت. او فعالیت حرفه ای خود را،در عرصه بازیگری، با بازی در مجموعه تلویزیونی پژمان به کارگردانی سروش صحت در سال 1392، آغاز نمود و با بازی در فیلم آتش بس 2 به کارگردانی تهمینه میلانی وارد عرصه سینما شد. او در سال ۱۳۹۲ با بازی در تئاتر بادی که تو را خشک کرد مرا برد، به کارگردانی علی نرگس نژاد برای نخستین بار به روی صحنه رفت؛ از دیگر بازی های او در تئاتر می‌توان به آرسنیک و تور کهنه، یادم تو را فراموش، پپرونی برای دیکتاتور و فرانکنشتاین اشاره کرد. جمشیدی برای بازی در فیلم های سینمایی سوء تفاهم و شیشلیک، نامزد بهترین بازیگر نقش مکمل مرد در دوره سی و ششم و سی ونهم جشنواره بین المللی فجر شد. "
                        },
                        new Actor()
                        {
                            FullName = "Parsa Pirouzfar",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/bb/0f/bb0fc49aa28da3c7e2c3f2707c89654a.webp",
                            Age = 40,
                            Bio = "پارسا پیروزفر، در ۲۲ شهریور ماه سال ۱۳۵۱ در تهران به دنیا آمد. او دارای مدرک کارشناسی نقاشی از دانشکده هنرهای زیبای دانشگاه تهران واز دانش‌آموختگان رشته بازیگری از آکادمی هنرهای نمایشی استاد سمندریان است. علاقه‌ زیاد وی به نقاشی، موجب شد تا او در سال‌های ۱۳۶۳ تا ۱۳۶۹، زمانی که در مقطع دبیرستان رشته ریاضی و فیزیک مشغول تحصیل بود، به خلق داستان‌های مصور، مشغول باشد؛ او هنوز اقدامی برای چاپ داستانهای مصور خود انجام نداده است. نقش کوتاه او در فیلم پری، به کارگردانی داریوش مهرجویی اولین تجربه حضور او در عرصه سینما بود. وی در سال ۱۳۷۴، برای شرکت در دوره های بازیگری، به آکادمی هنرهای نمایشی سمندریان رفت. برای نخستین بار به صورت حرفه ای در سال ۱۳۷۴ در نقش ماریوس در نمایش بینوایان، اثر ویکتور هوگو به کارگردانی بهروز غریب پور، به ایفای نقش پرداخت. او با بازی در مجموعه تلویزیونی در پناه تو و در قلب من، در تلویزیون دیده شد و به شهرت بسیاری دست یافت. او برای اولین بار، نمایشنامه هنر، اثر یاسمینا رضا را در سال ۱۳۸۰، کارگردانی کرد. در سال ۱۳۸۲ با بازی حرفه ای در سریال در چشم باد، کاندید تندیس زرین بهترین بازیگر نقش اول مرد از دوازدهمین جشن دنیای تصویر شد. در سال‌های ۱۳۸۴ و ۱۳۸۵ به عنوان مدرس بازیگری در موسسه فرهنگی و هنری کارنامه مشغول شد. علاوه بر موسسه کارنامه و دانشگاه علامه طباطبایی، در سال‌های ۱۳۸۶، ۱۳۸۹ و ۱۳۹۰ در مدرسه فیلمسازی و پژوهش‌های سینمایی هیلاج به تدریس بازیگری پرداخت. از دیگر فعالیت‌های هنری او، می‌توان به فعالیت در زمینه طراحی گرافیک، ساختن تیزر و مجسمه‌سازی اشاره کرد. وی در سال ۱۳۸۲، برای بازی در فیلم مهمان مامان، به کارگردانی داریوش مهرجویی، جایزه بازیگری هشتمین جشن خانه سینما را دریافت کرد. "
                        },
                        new Actor()
                        {
                            FullName = "Elnaz Shakerdoost",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/ee/d9/eed9b4ab32917d41125dd2567b173b25.webp",
                            Age = 38,
                            Bio = "النازشاکردوست، بازیگر سینما و تئاتر در 7 تیر سال 1363 در محله پاسداران تهران به دنیا آمد. .وی فرزند دوم خانواده است و یک خواهر کوچکتر به نام الیکا و یک برادر به نام علی دارد . پدرش نیز تاجر ابزارآلات صنعتی و مادرش خانه دار می باشد. او در دوران کودکی به نواختن پیانو علاقه داشت وبا اینکه مخالفتی از جانب خانواده برای ورود او به عرصه هنر نبود، اما در دبیرستان رشته ریاضی و فیزیک را انتخاب کرد و دیپلم خود را با معدل 19.23 گرفت. گوهر خیراندیش یکی از صمیمی‌ترین دوست‌هاي اوسـت و این دو هنرمند محبوب با وجود اختلاف سنی بیش از بیست‌ ساله‌ ای که دارند، مدت‌هاست دوستان صمیمی یکدیگر هستند. الناز شاکردوست در کنکور هنر با رتبه 11 رشته بازیگری تئاتر را برای ادامه تحصیل انتخاب کرد. تحصیلاتش را در دانشکده هنر و معماری تهران به اتمام رساند و همچنین او لیسانس رشته نمایش و طراحی صحنه از دانشگاه آزاد تهران-مرکز و فوق لیسانس هنر از دانشگاه لندن انگلستان دارد. او بازیگری را با تئاتر آغاز کرد. در سن 19 سالگی در فیلم گل یخ به کارگردانی کیومرث پوراحمد در سال 1383 به ایفای نقش پرداخت. او در مدت یک سال در چهار فیلم سینمایی بازی کرد و تبدیل به یکی از ستارگان پرطرفدار سینما شد. در تجربه دومش \"مجردها\" بازی متفاوتی از خود به نمایش گذاشت. بعد ازآن‌هم در \"عروس فراری\" برای نخستین بار در مقابل امین حیایی قرار گرفت. زوج او با امین حیایی و محمدرضا گلزار بارها در آثاری همچون \"چـه کسی امیر را کشت\"، \"مجنون لیلی\"، \"دو خواهر\" و \"آتیش بازی\" و… تکرار شد. وی با نقش‌آفرینی در مجموعه \"قلب یخی\" به کارگردانی محمدحسین لطیفی برای نخستین بار در مدیومی غیر از سینما دیده شد. در سال 1396 الناز شاکردوست در پشت‌صحنه فیلم سینمایی دو طبقه روی پیلوت، دچار سانحه‌ اي خطرناک شد و از ناحیه کمر، آسیب جدی بـه مهره‌هاي ستون فقراتش وارد شد. در سال 1397، او در\"فیلم شبی که ماه کامل شد\" به کارگردانی نرگس آبیار به ایفای نقش پرداخت و سیمرغ بهترین بازیگر نقش زن را از آن خود کرد. "
                        },
                        new Actor()
                        {
                            FullName = "Hootan Shakaiba",
                            ProfilePictureUrl = "https://static.cdn.asset.cinematicket.org/media/cache/40/a9/40a92ae6fc3b89a644f4bee862ddee66.webp",
                            Age = 38,
                            Bio = "هوتن شکیبا متولد ۲۴ خرداد ۱۳۶۳ هنرپیشه و صداپیشه اهل ایران است. او که با بازی در سریال لیسانسه‌ها شهرت پیدا کرد، در سی و هفتمین دوره جشنواره فیلم فجر، برای بازی در فیلم شبی که ماه کامل شد، موفق به دریافت سیمرغ بلورین بهترین بازیگر نقش اول مرد گردید. "
                        },
                        //new Actor()
                        //{
                        //    FullName = "",
                        //    ProfilePictureUrl = "",
                        //    Age = ,
                        //    Bio = ""
                        //},
                    });
                    context.SaveChanges();
                }
                //Directors
                if (!context.Directors.Any())
                {
                    context.Directors.Add(new Director()
                    {
                        FullName = "Ali Tolouie"
                    });
                    context.SaveChanges();

                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title= "Bokharest",
                            BreifStory = "بخارست فیلمی به کارگردانی سیدمسعود اطیابی، تهیه‌کنندگی علی طلوعی است و ژانری کمدی دارد. در این فیلم بازیگران کمدی مطرحی همچون حسین یاری، پزمان جمشیدی، امیرحسین آرمان، هادی کاظمی، غلامرضا نیکخواه به ایفای نقش پرداخته‌اند. نویسنده: حمزه صالحی، دستیار اول کارگردان محمد داودی‌کیا، مشاوره تهیه‌کننده: ایرج محمدی، مدیر تولید: سید حمیدرضا اطیابی، مدیر فیلمبرداری: افشین علیزاده، آهنگساز: امیر توسلی، تدوین: مهسا‌السادات اطیابی، مدیر برنامه‌ریزی: نرگس مشایخی، جلوه‌های ویژه میدانی: حمید رسولیان، جلوه‌های ویژه بصری و تیتراژ: محمد میر وهابی، طراح صحنه: سعید هنرمند، مدیر صدابرداری: عباس رستگارپور طراح لباس: افسانه صمدزاده، عکاس و فیلمبردار دوم: سیدحسام اطیابی و ... برخی عوامل بخارست را شامل می‌شوند. خلاصه فیلم: اینجا ایران است و ما داستان‌های هیجان‌انگیز داریم. ",
                            ImageUrl = "https://static.cdn.asset.cinematicket.org/media/cache/02/4c/024cb62665d470be1dddc05c9f0fa820.webp",
                            MovieCategoy = MovieCategoy.Comedy,
                            CinemaStart = DateTime.Now,
                            CinemaEnd = DateTime.Now.AddDays(14),
                        },
                        new Movie()
                        {
                            Title= "Titi",
                            BreifStory = "فیلم تی تی چهارمین ساخته‌ی آیدا پناهنده است. این فیلم که ژانری درام دارد، به‌صورت کامل در گیلان فیلمبرداری شده است. این فیلم در سی‌و‌نهمین دوره‌ی جشنواره‌ی فجر نیز حضور داشت. همچنین جایزه‌ی بهترین فیلم از نگاه تماشاگران در فستیوال بین‌المللی تصاویر نو پارسی 1400، بهترین بازیگر زن در بیست‌و‌ششمین فستیوال بین‌المللی سینمای مولف رباط-مراکش 1400 و چهاردهمین جشن بزرگ منتقدان و نویسندگان سینمای ایران 1401 کسب کردند. در تی تی بازیگران مطرحی همچون الناز شاکردوست، هوتن شکیبا و پارسا پیروزفر ایفای نقش می‌کنند. خلاصه فیلم: ابراهیم، استاد فیزیک دانشگاه در آستانه‌ی مرگ با زنی روستایی آشنا می‌شود به طوریکه زندگی و مرگ ابراهیم را از نو معنا می‌کند.  ",
                            ImageUrl = "https://static.cdn.asset.cinematicket.org/media/cache/c3/b6/c3b6763f27c979221cfd0ebb8751c523.webp",
                            MovieCategoy = MovieCategoy.Drama,
                            CinemaStart = DateTime.Now,
                            CinemaEnd = DateTime.Now.AddDays(14),
                        },
                    });
                    context.SaveChanges();

                }

            }
        }
    }
}
