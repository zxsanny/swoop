using System.Text;
using FluentAssertions;
using Machine.Specifications;
using Swoop.Compressor;

namespace Swoop.Tests
{
    public class CompressorTests : IntegrationTests<NoemaxCompressor>
    {
        public static int TextLength;
        public static int CompressLength;
        #region longtext
    public static string longText = @"Led Zeppelin - 9 альбомов (10 CD) 


Жанр: Rock
Страна-производитель дисков: 
Japan
Год издания дисков: 1995
Аудио кодек: FLAC (*.flac)
Тип рипа: image+.cue
Битрейт аудио: lossless
Источник (релизер): Рипы с личных оригиналов
Наличие сканов в содержимом раздачи: 600 dpi, JPG


1969 - Led Zeppelin I
Led Zeppelin I 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records
Номер по каталогу: AMCY-4005
Продолжительность: 44:51--Треклист▼
01. Good Times Bad Times
02. Babe I'm Gonna Leave You
03. You Shook Me
04. Dazed and Confused
05. Your Time Is Gonna Come
06. Black Mountain Side
07. Communication Breakdown
08. I Can't Quit You Baby
09. How Many More Times







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 14. October 2014, 16:43
Led Zeppelin / Led Zeppelin
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  2:47.05 |         0    |    12529        2  |  2:47.05 |  6:41.32 |     12530    |    42636        3  |  9:28.37 |  6:27.73 |     42637    |    71734        4  | 15:56.35 |  6:26.02 |     71735    |   100686        5  | 22:22.37 |  4:34.60 |    100687    |   121296        6  | 26:57.22 |  2:12.43 |    121297    |   131239        7  | 29:09.65 |  2:29.65 |    131240    |   142479        8  | 31:39.55 |  4:42.60 |    142480    |   163689        9  | 36:22.40 |  8:28.47 |    163690    |   201836
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1969 - Led Zeppelin I (Atlantic AMCY-4005, Japan, Remastered) 1995\Led Zeppelin - Led Zeppelin.wav
     Peak level 100.0 %     Extraction speed 0.4 X     Range quality 100.0 %     Test CRC 32C80DDA     Copy CRC 32C80DDA     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 5)  [632A946A]Track  2  accurately ripped (confidence 4)  [3B10209B]Track  3  accurately ripped (confidence 5)  [02C7195E]Track  4  accurately ripped (confidence 5)  [3406D16D]Track  5  accurately ripped (confidence 5)  [9E24F0EB]Track  6  accurately ripped (confidence 5)  [2EFF2FE4]Track  7  accurately ripped (confidence 5)  [5C18A386]Track  8  accurately ripped (confidence 5)  [32013FDC]Track  9  accurately ripped (confidence 5)  [B7F02D05]
All tracks accurately ripped
End of status report
==== Log checksum B9CB15AE7C464656A7238D5E2F8EA940BAE85DF5BDE0FBCEE06D1D88BDD41F2C ====





Скриншот спектра частот








1969 - Led Zeppelin II
Led Zeppelin II 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records
Номер по каталогу: AMCY-4006
Продолжительность: 41:30--Треклист▼
01. Whole Lotta Love
02. What Is and What Should Never Be
03. The Lemon Song
04. hank You
05. Heartbreaker
06. Living Loving Maid (She's Just a Woman)
07. Ramble On
08. Moby Dick
09. Bring It on Home







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 14. October 2014, 17:27
Led Zeppelin / Led Zeppelin II
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  5:35.17 |         0    |    25141        2  |  5:35.17 |  4:45.63 |     25142    |    46579        3  | 10:21.05 |  6:19.52 |     46580    |    75056        4  | 16:40.57 |  4:49.43 |     75057    |    96774        5  | 21:30.25 |  4:14.05 |     96775    |   115829        6  | 25:44.30 |  2:39.25 |    115830    |   127779        7  | 28:23.55 |  4:24.20 |    127780    |   147599        8  | 32:48.00 |  4:20.70 |    147600    |   167169        9  | 37:08.70 |  4:21.10 |    167170    |   186754
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1969 - Led Zeppelin II (Atlantic AMCY-4006, Japan, Remastered) 1995\Led Zeppelin - Led Zeppelin II.wav
     Peak level 100.0 %     Extraction speed 0.2 X     Range quality 100.0 %     Test CRC 6FE1F18C     Copy CRC 6FE1F18C     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 2)  [D2DEAF0F]Track  2  accurately ripped (confidence 2)  [796576BC]Track  3  accurately ripped (confidence 2)  [D7C5354A]Track  4  accurately ripped (confidence 2)  [6290863B]Track  5  accurately ripped (confidence 2)  [24D25166]Track  6  accurately ripped (confidence 2)  [2433FC17]Track  7  accurately ripped (confidence 2)  [F0B45E82]Track  8  accurately ripped (confidence 2)  [37671CE2]Track  9  accurately ripped (confidence 2)  [211206AF]
All tracks accurately ripped
End of status report
==== Log checksum 08A70CC1854B9FF592307E083D7826BECFD052373CAD2C986C60E1EA91D8CB34 ====





Скриншот спектра частот








1970 - Led Zeppelin III
Led Zeppelin III 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records
Номер по каталогу: AMCY-4007
Продолжительность: 43:03--Треклист▼
01. Immigrant Song
02. Friends
03. Celebration Day
04. Since I've Been Loving You
05. Out on the Tiles
06. Gallows Pole
07. Tangerine
08. That's the Way
09. Bron-Y-Aur Stomp
10. Hats off to (Roy) Harper







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 14. October 2014, 20:22
Led Zeppelin / Led Zeppelin III
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  2:25.70 |         0    |    10944        2  |  2:25.70 |  3:54.33 |     10945    |    28527        3  |  6:20.28 |  3:29.45 |     28528    |    44247        4  |  9:49.73 |  7:23.17 |     44248    |    77489        5  | 17:13.15 |  4:06.50 |     77490    |    95989        6  | 21:19.65 |  4:56.10 |     95990    |   118199        7  | 26:16.00 |  3:10.30 |    118200    |   132479        8  | 29:26.30 |  5:37.25 |    132480    |   157779        9  | 35:03.55 |  4:16.18 |    157780    |   176997       10  | 39:19.73 |  3:42.57 |    176998    |   193704
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1970 - Led Zeppelin III (Atlantic AMCY-4007, Japan, Remastered) 1995\Led Zeppelin - Led Zeppelin III.wav
     Peak level 100.0 %     Extraction speed 0.2 X     Range quality 100.0 %     Test CRC 6B5F98A2     Copy CRC 6B5F98A2     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 4)  [5719A4D0]Track  2  accurately ripped (confidence 4)  [62F75DCD]Track  3  accurately ripped (confidence 3)  [5272EE69]Track  4  accurately ripped (confidence 4)  [95CC6E6A]Track  5  accurately ripped (confidence 4)  [C499F238]Track  6  accurately ripped (confidence 4)  [B7C1F146]Track  7  accurately ripped (confidence 4)  [32850080]Track  8  accurately ripped (confidence 4)  [05696A5A]Track  9  accurately ripped (confidence 4)  [825FBC65]Track 10  accurately ripped (confidence 4)  [2CE74CDD]
All tracks accurately ripped
End of status report
==== Log checksum F7FA72A14EBB694C21BA003FBAE575DD093D20477592EE22297BA6C6DC190365 ====





Скриншот спектра частот








1971 - Led Zeppelin IV
Led Zeppelin IV 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records
Номер по каталогу: AMCY-4008
Продолжительность: 42:38--Треклист▼
01. Black Dog
02. Rock and Roll
03. The Battle of Evermore
04. Stairway to Heaven
05. Misty Mountain Hop
06. Four Sticks
07. Going to California
08. When the Levee Breaks







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 15. October 2014, 23:39
Led Zeppelin / Led Zeppelin IV
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  4:57.37 |         0    |    22311        2  |  4:57.37 |  3:40.53 |     22312    |    38864        3  |  8:38.15 |  5:52.22 |     38865    |    65286        4  | 14:30.37 |  8:03.00 |     65287    |   101511        5  | 22:33.37 |  4:38.68 |    101512    |   122429        6  | 27:12.30 |  4:45.12 |    122430    |   143816        7  | 31:57.42 |  3:31.48 |    143817    |   159689        8  | 35:29.15 |  7:08.52 |    159690    |   191841
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1971 - Led Zeppelin IV (Atlantic AMCY-4008, Japan, Remastered) 1995\Led Zeppelin - Led Zeppelin IV.wav
     Peak level 100.0 %     Extraction speed 0.3 X     Range quality 99.9 %     Test CRC 200A2C82     Copy CRC 200A2C82     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 4)  [4025CC50]Track  2  accurately ripped (confidence 4)  [9AC17F99]Track  3  accurately ripped (confidence 4)  [77F750FE]Track  4  accurately ripped (confidence 4)  [28D19DB5]Track  5  accurately ripped (confidence 4)  [1CD87C3B]Track  6  accurately ripped (confidence 4)  [4FF7E830]Track  7  accurately ripped (confidence 4)  [4AB0C12B]Track  8  accurately ripped (confidence 4)  [21F518E1]
All tracks accurately ripped
End of status report
==== Log checksum A54A35D8D58551FD7B8F88A11A3437AEBBD3B1462F31528B0D66E6CA9D5E7333 ====





Скриншот спектра частот








1973 - Houses of the Holy
Houses of the Holy 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records
Номер по каталогу: AMCY-4009
Продолжительность: 40:55--Треклист▼
01. The Song Remains the Same
02. The Rain Song
03. Over the Hills and Far Away
04. The Crunge
05. Dancing Days
06. D'Yer Mak'er
07. No Quarter
08. The Ocean







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 16. October 2014, 13:23
Led Zeppelin / Houses Of The Holy
Used drive  : PIONEER DVD-RW  DVR-212   Adapter: 1  ID: 0
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 48Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  5:30.47 |         0    |    24796        2  |  5:30.47 |  7:38.68 |     24797    |    59214        3  | 13:09.40 |  4:50.00 |     59215    |    80964        4  | 17:59.40 |  3:17.22 |     80965    |    95761        5  | 21:16.62 |  3:43.10 |     95762    |   112496        6  | 24:59.72 |  4:22.65 |    112497    |   132211        7  | 29:22.62 |  7:00.30 |    132212    |   163741        8  | 36:23.17 |  4:31.28 |    163742    |   184094
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1973 - Houses of the Holy (Atlantic AMCY-4009, Japan, Remastered) 1995\Led Zeppelin - Houses Of The Holy.wav
     Peak level 100.0 %     Extraction speed 0.8 X     Range quality 100.0 %     Test CRC 85FCE1F7     Copy CRC 85FCE1F7     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 9)  [C7F2EEF6]Track  2  accurately ripped (confidence 9)  [8E4E7238]Track  3  accurately ripped (confidence 9)  [A8BAA7B1]Track  4  accurately ripped (confidence 9)  [CF039184]Track  5  accurately ripped (confidence 9)  [E22E401A]Track  6  accurately ripped (confidence 9)  [911232B3]Track  7  accurately ripped (confidence 9)  [6A88CDAD]Track  8  accurately ripped (confidence 9)  [D5E7BA94]
All tracks accurately ripped
End of status report
==== Log checksum E0265D16F77A131EB4E79162E304F69238D975CFAF543E415DD398C01173596B ====





Скриншот спектра частот








1975 - Physical Graffiti
Physical Graffiti 




--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records/Swan Song
Номер по каталогу: AMCY-4010~1
Продолжительность: 39:05+43:40--Треклист▼
Disc 1
01. Custard Pie
02. The Rover
03. In My Time of Dying
04. Houses of the Holy
05. Trampled Under Foot
06. Kashmir
Disc 2
01. In the Light
02. Bron-Yr-Aur
03. Down by the Seaside
04. Ten Years Gone
05. Night Flight
06. The Wanton Song
07. Boogie with Stu
08. Black Country Woman
09. Sick Again







Лог создания рипа - Disc 1


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 16. October 2014, 14:20
Led Zeppelin / Physical Graffiti - Disc 1
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  4:14.22 |         0    |    19071        2  |  4:14.22 |  5:37.13 |     19072    |    44359        3  |  9:51.35 | 11:06.05 |     44360    |    94314        4  | 20:57.40 |  4:02.17 |     94315    |   112481        5  | 24:59.57 |  5:36.40 |    112482    |   137721        6  | 30:36.22 |  8:28.58 |    137722    |   175879
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1975 - Physical Graffiti (Atlantic AMCY-4010~1, Japan, Remastered) 1995\Disc 1\Led Zeppelin - Physical Graffiti - Disc 1.wav
     Peak level 100.0 %     Extraction speed 0.5 X     Range quality 100.0 %     Test CRC 75C52C1E     Copy CRC 75C52C1E     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 6)  [1E15D30D]Track  2  accurately ripped (confidence 6)  [C7912CCA]Track  3  accurately ripped (confidence 6)  [0E238B7F]Track  4  accurately ripped (confidence 6)  [AE22C475]Track  5  accurately ripped (confidence 6)  [583F46F6]Track  6  accurately ripped (confidence 6)  [DC00AC07]
All tracks accurately ripped
End of status report
==== Log checksum 5247190FB438A6F458F5BE3A4E57CE6529E3BD8424ADAC7241FB89317A44FBF1 ====





Лог создания рипа - Disc 2


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 16. October 2014, 16:03
Led Zeppelin / Physical Graffiti - Disc 2
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  8:47.20 |         0    |    39544        2  |  8:47.20 |  2:06.40 |     39545    |    49034        3  | 10:53.60 |  5:16.10 |     49035    |    72744        4  | 16:09.70 |  6:33.05 |     72745    |   102224        5  | 22:43.00 |  3:37.45 |    102225    |   118544        6  | 26:20.45 |  4:09.45 |    118545    |   137264        7  | 30:30.15 |  3:53.12 |    137265    |   154751        8  | 34:23.27 |  4:32.73 |    154752    |   175224        9  | 38:56.25 |  4:43.27 |    175225    |   196476
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1975 - Physical Graffiti (Atlantic AMCY-4010~1, Japan, Remastered) 1995\Disc 2\Led Zeppelin - Physical Graffiti - Disc 2.wav
     Peak level 100.0 %     Extraction speed 0.2 X     Range quality 100.0 %     Test CRC 22008E22     Copy CRC 22008E22     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 2)  [F480FB98]Track  2  accurately ripped (confidence 2)  [DAE3B612]Track  3  accurately ripped (confidence 2)  [1F35DF9A]Track  4  accurately ripped (confidence 2)  [E9A81E01]Track  5  accurately ripped (confidence 2)  [ECA9ECF3]Track  6  accurately ripped (confidence 2)  [65CD7A13]Track  7  accurately ripped (confidence 2)  [1A8EC07F]Track  8  accurately ripped (confidence 2)  [309C5492]Track  9  accurately ripped (confidence 2)  [47AA5782]
All tracks accurately ripped
End of status report
==== Log checksum 0AD579BBDB08A43378DDE285A0ECB24757589E3D50E49BF94F45CDD1C28247AD ====





Скриншот спектра частот - Disc 1






Скриншот спектра частот - Disc 2








1976 - Presence
Presence 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records/Swan Song
Номер по каталогу: AMCY-4012
Продолжительность: 44:28--Треклист▼
01. Achilles Last Stand
02. For Your Life
03. Royal Orleans
04. Nobody's Fault But Mine
05. Candy Store Rock
06. Hots On For Nowhere
07. Tea For One







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 16. October 2014, 18:53
Led Zeppelin / Presence
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations    
    : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 | 10:25.32 |         0    |    46906        2  | 10:25.32 |  6:24.18 |     46907    
        |    75724        3  | 16:49.50 |  2:59.17 |     75725    |    89166        4  | 19:48.67 |  6:16.60 |     89167    |   117426        5  | 26:05.52 |  4:11.45 |    117427    |   136296        6  | 30:17.22 |  4:44.13 |    
        136297    |   157609        7  | 35:01.35 |  9:27.02 |    157610    |   200136
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1976 - Presence (Atlantic AMCY-4012, Japan, Remastered) 1995\Led Zeppelin - Presence.wav
     Peak level 100.0 %     Extraction speed 0.5 X     Range quality 99.9 %     Test CRC BE9D0662     Copy CRC BE9D0662     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 11)  [C3D96360]Track  2  accurately ripped (confidence 11)  [972DC411]Track  3  accurately ripped (confidence 10)  [47501AA9]Track  4  accurately ripped (confidence 11)  [A55533F8]Track  5  accurately ripped (confidence 11)  [8427B0F4]Track  6  accurately ripped (confidence 11)  [A507B72A]Track  7  accurately ripped (confidence 11)  [1A9C975C]
All tracks accurately ripped
End of status report
==== Log checksum D3226BDAFD7F74AD113EFE3314827AC358ADCB89911B41716D5122425487DB7A ====





Скриншот спектра частот








1979 - In Through The Out Door
In Through The Out Door 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records/Swan Song
Номер по каталогу: AMCY-4013
Продолжительность: 42:36--Треклист▼
01. In The Evening
02. South Bound Saurez
03. Fool In The Rain
04. Hot Dog
05. Carouselambra
06. All My Love
07. I'm Gonna Crawl







Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 16. October 2014, 19:43
Led Zeppelin / In Through The Out Door
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  6:51.00 |         0    |    30824        2  |  6:51.00 |  4:14.25 |     30825    |    49899        3  | 11:05.25 |  6:12.67 |     49900    |    77866        4  | 17:18.17 |  3:17.10 |     77867    |    92651        5  | 20:35.27 | 10:34.28 |     92652    |   140229        6  | 31:09.55 |  5:56.17 |    140230    |   166946        7  | 37:05.72 |  5:30.13 |    166947    |   191709
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1979 - In Through The Out Door (Atlantic AMCY-4013, Japan, Remastered) 1995\Led Zeppelin - In Through The Out Door.wav
     Peak level 100.0 %     Extraction speed 0.3 X     Range quality 100.0 %     Test CRC 4AE28FE2     Copy CRC 4AE28FE2     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 7)  [3D37C08F]Track  2  accurately ripped (confidence 7)  [4E13538D]Track  3  accurately ripped (confidence 7)  [00B2D13E]Track  4  accurately ripped (confidence 7)  [CE9A4D06]Track  5  accurately ripped (confidence 7)  [A3942AF6]Track  6  accurately ripped (confidence 7)  [B9220569]Track  7  accurately ripped (confidence 7)  [4566F7DE]
All tracks accurately ripped
End of status report
==== Log checksum 102AF2589E0F1E79643B140E859F8B79431AE023F883FA667EA7C3CE3E39BBDF ====





Скриншот спектра частот








1982 - Coda
Coda 


--Страна-производитель диска: 
Japan
Год издания диска: 1995
Издатель (лейбл): Atlantic Records/Swan Song
Номер по каталогу: AMCY-4014
Продолжительность: 33:01--Треклист▼
01. We're Gonna Groove
02. Poor Tom
03. I Can't Quit You Baby
04. Walter's Walk
05. Ozone Baby
06. Darlene
07. Bonzo's Montreux
08. Wearing And Tearing








Лог создания рипа


Exact Audio Copy V1.0 beta 1 from 15. November 2010
EAC extraction logfile from 2. April 2015, 3:56
Led Zeppelin / Coda
Used drive  : PLEXTOR DVDR   PX-760A   Adapter: 4  ID: 2
Read mode               : SecureUtilize accurate stream : YesDefeat audio cache      : YesMake use of C2 pointers : No
Read offset correction                      : 30Overread into Lead-In and Lead-Out          : NoFill up missing offset samples with silence : YesDelete leading and trailing silent blocks   : NoNull samples used in CRC calculations       : YesUsed interface                              : Native Win32 interface for Win NT & 2000
Used output format : Internal WAV RoutinesSample format      : 44.100 Hz; 16 Bit; Stereo
TOC of the extracted CD
     Track |   Start  |  Length  | Start sector | End sector    ---------------------------------------------------------        1  |  0:00.00 |  2:38.17 |         0    |    11866        2  |  2:38.17 |  3:02.08 |     11867    |    25524        3  |  5:40.25 |  4:18.05 |     25525    |    44879        4  |  9:58.30 |  4:31.00 |     44880    |    65204        5  | 14:29.30 |  3:35.65 |     65205    |    81394        6  | 18:05.20 |  5:07.12 |     81395    |   104431        7  | 23:12.32 |  4:18.38 |    104432    |   123819        8  | 27:30.70 |  5:29.70 |    123820    |   148564
Range status and errors
Selected range
     Filename F:\FLAC (bruk67)\Led Zeppelin (Japan, Remastered) 1995\1982 - Coda (Atlantic AMCY-4014, Japan, Remastered) 1995\Led Zeppelin - Coda.wav
     Peak level 100.0 %     Extraction speed 0.4 X     Range quality 100.0 %     Test CRC C8CB4EE8     Copy CRC C8CB4EE8     Copy OK
No errors occurred
AccurateRip summary
Track  1  accurately ripped (confidence 7)  [CFFE33E2]Track  2  accurately ripped (confidence 7)  [CBBE83D7]Track  3  accurately ripped (confidence 7)  [D44B9537]Track  4  accurately ripped (confidence 7)  [CA467A5B]Track  5  accurately ripped (confidence 7)  [C16E25BF]Track  6  accurately ripped (confidence 7)  [FC34CA7B]Track  7  accurately ripped (confidence 7)  [EE04B2CD]Track  8  accurately ripped (confidence 6)  [4F793F9D]
All tracks accurately ripped
End of status report
==== Log checksum D6F47789811CCBF9DB8924CC72BCF50EF9C3EA1AC770428DEDC9808ACCDDE0DE ====





Скриншот спектра частот";
#endregion

        private Because of = () =>
        {
            var input = Encoding.UTF8.GetBytes(longText);
            TextLength = input.Length;
            var bytes = Subject.Compress(longText);
            CompressLength = bytes.Length;
        };

        private It should_be_compressed = () =>
        {
            CompressLength.Should().BeLessThan(TextLength);
        };
    }
}
