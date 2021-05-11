Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
    Dim SpriteMask As CImage
    Dim MegamanIntro, MegamanRunStart, MegamanRun, MagnaStand, MagnaJump, MagnaIntro, MagnaHit, MagnaDead, MagnaThrowing, MagnaMagnet, MagnaTail, MagnaVanish, MagnaAppear, MagnaPartTail, MagnaPartTail1, Shuriken, ShurikenStart1, ShurikenStart2, ShurikenStart3 As CArrFrame
    Dim MagnaStandUD, MagnaJumpUD, MagnaThrowingUD, MagnaMagnetUD, MagnaTailUD, MagnaVanishUD, MagnaAppearUD, MegamanMagnetStart, MegamanMagnetHit As CArrFrame
    Dim ListChar As New List(Of CCharacter)
    Dim Collision As Boolean
    Dim MC As CCharMagna
    Dim MM As CCharMegaMan
    Dim Randomizer As New Random
    Dim resultrand As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'open image for background, assign to bg
        Bg = New CImage
        Bg.OpenImage("Image\094.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage("Image\MCSpriteSheet3.bmp")

        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites

        MagnaIntro = New CArrFrame
        MagnaIntro.Insert(33, 127, 6, 90, 62, 163, 3)
        MagnaIntro.Insert(91, 127, 67, 90, 115, 163, 3)
        MagnaIntro.Insert(146, 127, 120, 90, 171, 163, 3)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 2)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 2)
        MagnaIntro.Insert(305, 127, 281, 90, 328, 163, 2)
        MagnaIntro.Insert(305, 127, 281, 90, 328, 163, 2)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 2)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 2)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 2)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 2)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 2)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 2)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 2)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 2)
        MagnaIntro.Insert(305, 127, 281, 90, 328, 163, 2)

        MagnaStand = New CArrFrame
        MagnaStand.Insert(603, 50, 576, 14, 631, 87, 4)
        MagnaStand.Insert(670, 51, 642, 14, 699, 87, 4)
        MagnaStand.Insert(737, 51, 709, 14, 766, 87, 4)
        MagnaStand.Insert(805, 51, 777, 14, 833, 87, 4)

        MagnaStandUD = New CArrFrame
        MagnaStandUD.Insert(805, 2090, 776, 2053, 833, 2127, 4)
        MagnaStandUD.Insert(737, 2090, 708, 2053, 766, 2127, 4)
        MagnaStandUD.Insert(671, 2090, 641, 2053, 699, 2127, 4)
        MagnaStandUD.Insert(603, 2091, 573, 2054, 633, 2127, 4)

        MagnaJump = New CArrFrame
        MagnaJump.Insert(38, 218, 12, 186, 62, 250, 2)
        MagnaJump.Insert(93, 219, 66, 186, 117, 250, 2)
        MagnaJump.Insert(148, 218, 125, 186, 172, 250, 2)
        MagnaJump.Insert(206, 218, 176, 186, 234, 250, 2)
        MagnaJump.Insert(370, 219, 352, 186, 386, 250, 3)
        MagnaJump.Insert(409, 218, 391, 186, 427, 250, 3)
        MagnaJump.Insert(370, 219, 352, 186, 386, 250, 3)
        MagnaJump.Insert(409, 218, 391, 186, 427, 250, 3)
        MagnaJump.Insert(370, 219, 352, 186, 386, 250, 3)
        MagnaJump.Insert(409, 218, 391, 186, 427, 250, 3)
        MagnaJump.Insert(411, 1923, 392, 1888, 429, 1957, 3) 'ud
        MagnaJump.Insert(371, 1923, 353, 1888, 388, 1957, 3)
        MagnaJump.Insert(411, 1923, 392, 1888, 429, 1957, 3)
        MagnaJump.Insert(260, 1925, 239, 1885, 280, 1972, 2)
        MagnaJump.Insert(315, 1923, 284, 1888, 345, 1957, 2)

        MagnaJumpUD = New CArrFrame
        MagnaJumpUD.Insert(38, 1923, 13, 1888, 63, 1957, 2)
        MagnaJumpUD.Insert(93, 1923, 67, 1888, 119, 1957, 2)
        MagnaJumpUD.Insert(147, 1923, 123, 1888, 170, 1957, 2)
        MagnaJumpUD.Insert(205, 1923, 174, 1888, 235, 1957, 2)
        MagnaJumpUD.Insert(371, 1923, 353, 1888, 388, 1957, 3)
        MagnaJumpUD.Insert(411, 1923, 392, 1888, 429, 1957, 3)
        MagnaJumpUD.Insert(371, 1923, 353, 1888, 388, 1957, 3)
        MagnaJumpUD.Insert(411, 1923, 392, 1888, 429, 1957, 3)
        MagnaJumpUD.Insert(371, 1923, 353, 1888, 388, 1957, 3)
        MagnaJumpUD.Insert(411, 1923, 392, 1888, 429, 1957, 3)
        MagnaJumpUD.Insert(409, 218, 391, 186, 427, 250, 3) 'non ud
        MagnaJumpUD.Insert(370, 219, 352, 186, 386, 250, 3)
        MagnaJumpUD.Insert(409, 218, 391, 186, 427, 250, 3)
        MagnaJumpUD.Insert(259, 216, 238, 187, 279, 253, 2)
        MagnaJumpUD.Insert(314, 218, 284, 186, 343, 250, 2)

        MagnaHit = New CArrFrame
        MagnaHit.Insert(36, 536, 14, 503, 57, 569, 5)
        MagnaHit.Insert(99, 536, 72, 503, 125, 569, 15)

        MagnaDead = New CArrFrame
        MagnaDead.Insert(32, 736, 13, 706, 51, 765, 5)
        MagnaDead.Insert(88, 736, 65, 706, 111, 765, 10)

        MagnaThrowing = New CArrFrame
        MagnaThrowing.Insert(33, 376, 6, 339, 61, 411, 3)
        MagnaThrowing.Insert(95, 376, 66, 339, 123, 411, 3)
        MagnaThrowing.Insert(152, 376, 128, 339, 175, 411, 4)
        MagnaThrowing.Insert(208, 376, 179, 339, 236, 411, 4)
        MagnaThrowing.Insert(267, 376, 239, 339, 295, 411, 4)
        MagnaThrowing.Insert(326, 375, 299, 339, 353, 411, 4)

        MagnaThrowingUD = New CArrFrame
        MagnaThrowingUD.Insert(34, 1765, 5, 1728, 62, 1801, 3)
        MagnaThrowingUD.Insert(95, 1765, 66, 1728, 123, 1801, 3)
        MagnaThrowingUD.Insert(152, 1765, 127, 1728, 177, 1801, 4)
        MagnaThrowingUD.Insert(208, 1765, 179, 1728, 237, 1801, 4)
        MagnaThrowingUD.Insert(269, 1765, 241, 1728, 296, 1801, 4)
        MagnaThrowingUD.Insert(327, 1765, 300, 1728, 354, 1801, 4)

        MagnaMagnet = New CArrFrame
        MagnaMagnet.Insert(42, 455, 19, 419, 65, 492, 4)
        MagnaMagnet.Insert(92, 455, 65, 419, 119, 492, 4)
        MagnaMagnet.Insert(147, 455, 119, 419, 175, 492, 4)
        MagnaMagnet.Insert(203, 455, 175, 419, 231, 492, 4)
        MagnaMagnet.Insert(147, 455, 119, 419, 175, 492, 4)
        MagnaMagnet.Insert(203, 455, 175, 419, 231, 492, 4)
        MagnaMagnet.Insert(147, 455, 119, 419, 175, 492, 4)
        MagnaMagnet.Insert(203, 455, 175, 419, 231, 492, 4)
        MagnaMagnet.Insert(147, 455, 119, 419, 175, 492, 4)
        MagnaMagnet.Insert(203, 455, 175, 419, 231, 492, 4)
        MagnaMagnet.Insert(260, 455, 231, 419, 289, 492, 4)
        MagnaMagnet.Insert(316, 455, 289, 419, 343, 492, 4)

        MagnaMagnetUD = New CArrFrame
        MagnaMagnetUD.Insert(40, 1684, 17, 1647, 63, 1721, 4)
        MagnaMagnetUD.Insert(92, 1684, 66, 1647, 117, 1721, 4)
        MagnaMagnetUD.Insert(147, 1684, 121, 1647, 172, 1721, 4)
        MagnaMagnetUD.Insert(202, 1684, 176, 1647, 228, 1721, 4)
        MagnaMagnetUD.Insert(147, 1684, 121, 1647, 172, 1721, 4)
        MagnaMagnetUD.Insert(202, 1684, 176, 1647, 228, 1721, 4)
        MagnaMagnetUD.Insert(147, 1684, 121, 1647, 172, 1721, 4)
        MagnaMagnetUD.Insert(202, 1684, 176, 1647, 228, 1721, 4)
        MagnaMagnetUD.Insert(147, 1684, 121, 1647, 172, 1721, 4)
        MagnaMagnetUD.Insert(202, 1684, 176, 1647, 228, 1721, 4)
        MagnaMagnetUD.Insert(262, 1684, 236, 1647, 287, 1721, 4)
        MagnaMagnetUD.Insert(317, 1684, 291, 1647, 343, 1721, 4)

        MagnaTail = New CArrFrame
        MagnaTail.Insert(39, 298, 16, 259, 63, 335, 3)
        MagnaTail.Insert(92, 298, 67, 259, 115, 335, 3)
        MagnaTail.Insert(145, 298, 120, 259, 169, 335, 3)
        MagnaTail.Insert(197, 298, 174, 259, 220, 335, 3)
        MagnaTail.Insert(248, 298, 225, 259, 272, 335, 3)
        MagnaTail.Insert(303, 298, 276, 259, 329, 335, 3)
        MagnaTail.Insert(360, 298, 333, 259, 386, 335, 3)
        MagnaTail.Insert(417, 298, 390, 259, 444, 335, 1)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 1)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 3)
        MagnaTail.Insert(587, 298, 562, 259, 612, 335, 3)

        MagnaTailUD = New CArrFrame
        MagnaTailUD.Insert(40, 1843, 16, 1805, 63, 1880, 3)
        MagnaTailUD.Insert(91, 1843, 67, 1805, 115, 1880, 3)
        MagnaTailUD.Insert(145, 1843, 121, 1805, 169, 1880, 3)
        MagnaTailUD.Insert(197, 1843, 173, 1805, 220, 1880, 3)
        MagnaTailUD.Insert(249, 1843, 224, 1805, 273, 1880, 3)
        MagnaTailUD.Insert(304, 1843, 277, 1805, 330, 1880, 3)
        MagnaTailUD.Insert(361, 1843, 334, 1805, 387, 1880, 3)
        MagnaTailUD.Insert(418, 1843, 391, 1805, 444, 1880, 1)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 2)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 2)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 2)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 1)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(531, 1843, 504, 1805, 558, 1880, 3)
        MagnaTailUD.Insert(474, 1843, 448, 1805, 500, 1880, 3)
        MagnaTailUD.Insert(588, 1843, 562, 1805, 613, 1880, 3)

        MagnaVanish = New CArrFrame
        MagnaVanish.Insert(25, 977, 6, 947, 44, 1005, 4)
        MagnaVanish.Insert(67, 976, 47, 947, 87, 1005, 3)
        MagnaVanish.Insert(110, 976, 90, 947, 129, 1005, 3)
        MagnaVanish.Insert(110, 976, 95, 952, 124, 1000, 3)
        MagnaVanish.Insert(110, 976, 100, 957, 119, 995, 3)
        MagnaVanish.Insert(110, 976, 105, 962, 114, 990, 3)

        MagnaVanishUD = New CArrFrame
        MagnaVanishUD.Insert(26, 1164, 6, 1134, 45, 1193, 4)
        MagnaVanishUD.Insert(67, 1164, 48, 1134, 86, 1193, 3)
        MagnaVanishUD.Insert(108, 1164, 90, 1134, 125, 1193, 3)
        MagnaVanishUD.Insert(108, 1164, 95, 1139, 120, 1188, 3)
        MagnaVanishUD.Insert(108, 1164, 100, 1144, 115, 1183, 3)
        MagnaVanishUD.Insert(108, 1164, 105, 1149, 110, 1178, 3)

        MagnaAppear = New CArrFrame
        MagnaAppear.Insert(110, 976, 105, 962, 114, 990, 3)
        MagnaAppear.Insert(110, 976, 100, 957, 119, 995, 3)
        MagnaAppear.Insert(110, 976, 95, 952, 124, 1000, 3)
        MagnaAppear.Insert(110, 976, 90, 947, 129, 1005, 3)
        MagnaAppear.Insert(67, 976, 47, 947, 87, 1005, 3)
        MagnaAppear.Insert(25, 977, 6, 947, 44, 1005, 4)

        MagnaAppearUD = New CArrFrame
        MagnaAppearUD.Insert(108, 1164, 105, 1149, 110, 1178, 3)
        MagnaAppearUD.Insert(108, 1164, 100, 1144, 115, 1183, 3)
        MagnaAppearUD.Insert(108, 1164, 95, 1139, 120, 1188, 3)
        MagnaAppearUD.Insert(108, 1164, 90, 1134, 125, 1193, 3)
        MagnaAppearUD.Insert(67, 1164, 48, 1134, 86, 1193, 3)
        MagnaAppearUD.Insert(26, 1164, 6, 1134, 45, 1193, 4)

        MagnaPartTail = New CArrFrame
        MagnaPartTail.Insert(15, 840, 8, 833, 23, 847, 1)
        MagnaPartTail.Insert(31, 840, 24, 833, 40, 847, 1)
        MagnaPartTail.Insert(58, 840, 47, 833, 68, 847, 1)
        MagnaPartTail.Insert(82, 840, 73, 833, 91, 847, 1)
        MagnaPartTail.Insert(108, 840, 96, 833, 119, 847, 1)
        MagnaPartTail.Insert(108, 840, 96, 833, 119, 847, 1)
        MagnaPartTail.Insert(82, 840, 73, 833, 91, 847, 1)
        MagnaPartTail.Insert(58, 840, 47, 833, 68, 847, 1)
        MagnaPartTail.Insert(31, 840, 24, 833, 40, 847, 1)
        MagnaPartTail.Insert(15, 840, 8, 833, 23, 847, 1)

        MagnaPartTail1 = New CArrFrame
        'MagnaPartTail.Insert(15, 821, 8, 814, 23, 829, 1)
        'MagnaPartTail.Insert(31, 821, 23, 841, 40, 829, 1)
        'MagnaPartTail.Insert(53, 824, 46, 819, 59, 830, 1)
        'MagnaPartTail.Insert(15, 838, 8, 832, 23, 845, 1)
        'MagnaPartTail.Insert(31, 838, 23, 721, 40, 845, 1)
        'MagnaPartTail.Insert(58, 838, 48, 832, 68, 845, 1)
        'MagnaPartTail.Insert(81, 838, 72, 832, 91, 845, 1)
        'MagnaPartTail.Insert(107, 838, 97, 832, 117, 845, 1)

        ShurikenStart1 = New CArrFrame
        ShurikenStart1.Insert(161, 913, 155, 908, 166, 914, 3)

        ShurikenStart2 = New CArrFrame
        ShurikenStart2.Insert(161, 913, 155, 908, 166, 914, 5)

        ShurikenStart3 = New CArrFrame
        ShurikenStart3.Insert(161, 913, 155, 908, 166, 914, 7)

        Shuriken = New CArrFrame
        Shuriken.Insert(160, 913, 155, 908, 166, 914, 1)
        Shuriken.Insert(169, 913, 166, 908, 174, 914, 1)
        Shuriken.Insert(178, 913, 174, 908, 183, 914, 1)

        MegamanRunStart = New CArrFrame

        MegamanRunStart.Insert(1171, 614, 1142, 580, 1200, 648, 1)

        MC = New CCharMagna
        ReDim MC.ArrSprites(16)
        MC.ArrSprites(0) = MagnaIntro
        MC.ArrSprites(1) = MagnaStand
        MC.ArrSprites(2) = MagnaJump
        MC.ArrSprites(3) = MagnaHit
        MC.ArrSprites(4) = MagnaDead
        MC.ArrSprites(5) = MagnaThrowing
        MC.ArrSprites(6) = MagnaMagnet
        MC.ArrSprites(7) = MagnaTail
        MC.ArrSprites(8) = MagnaVanish
        MC.ArrSprites(9) = MagnaAppear
        MC.ArrSprites(10) = MagnaStandUD
        MC.ArrSprites(11) = MagnaJumpUD
        MC.ArrSprites(12) = MagnaThrowingUD
        MC.ArrSprites(13) = MagnaMagnetUD
        MC.ArrSprites(14) = MagnaTailUD
        MC.ArrSprites(15) = MagnaVanishUD
        MC.ArrSprites(16) = MagnaAppearUD

        MC.PosX = 200
        MC.PosY = 158
        MC.Vx = 0
        MC.Vy = 0
        MC.State(StateMagnaCenti.Intro, 0)
        MC.FDir = FaceDir.Left

        ListChar.Add(MC)

        MegamanRunStart = New CArrFrame
        MegamanRunStart.Insert(676, 167, 659, 148, 694, 187, 1)

        MegamanIntro = New CArrFrame
        MegamanIntro.Insert(669, 127, 652, 108, 687, 147, 1)
        MegamanIntro.Insert(705, 127, 687, 108, 724, 147, 1)
        MegamanIntro.Insert(742, 127, 724, 108, 761, 147, 1)
        MegamanIntro.Insert(779, 127, 761, 108, 798, 147, 1)
        MegamanIntro.Insert(742, 127, 724, 108, 761, 147, 1)

        MegamanRun = New CArrFrame
        MegamanRun.Insert(717, 167, 705, 148, 729, 187, 1)
        MegamanRun.Insert(745, 167, 729, 148, 761, 187, 1)
        MegamanRun.Insert(781, 167, 761, 148, 802, 187, 1)
        MegamanRun.Insert(824, 167, 802, 148, 847, 187, 1)
        MegamanRun.Insert(869, 167, 853, 148, 886, 187, 1)
        MegamanRun.Insert(900, 167, 886, 148, 914, 187, 1)
        MegamanRun.Insert(930, 167, 914, 148, 947, 187, 1)
        MegamanRun.Insert(967, 167, 947, 148, 987, 187, 1)
        MegamanRun.Insert(1008, 167, 987, 148, 1030, 187, 1)
        MegamanRun.Insert(1050, 167, 1030, 148, 1071, 187, 1)

        MegamanMagnetStart = New CArrFrame
        MegamanMagnetStart.Insert(675, 321, 661, 301, 690, 341, 3)
        MegamanMagnetStart.Insert(700, 322, 690, 301, 711, 344, 3)
        MegamanMagnetStart.Insert(723, 323, 711, 299, 736, 348, 3)
        MegamanMagnetStart.Insert(749, 323, 736, 299, 762, 348, 3)
        MegamanMagnetStart.Insert(779, 326, 762, 304, 796, 348, 3)

        MegamanMagnetHit = New CArrFrame
        MegamanMagnetHit.Insert(819, 323, 804, 303, 835, 343, 3)
        MegamanMagnetHit.Insert(851, 323, 835, 303, 867, 343, 3)
        MegamanMagnetHit.Insert(819, 323, 804, 303, 835, 343, 3)
        MegamanMagnetHit.Insert(851, 323, 835, 303, 867, 343, 3)
        MegamanMagnetHit.Insert(819, 323, 804, 303, 835, 343, 3)
        MegamanMagnetHit.Insert(851, 323, 835, 303, 867, 343, 3)

        MM = New CCharMegaMan
        ReDim MM.ArrSprites(4)
        MM.ArrSprites(0) = MegamanIntro
        MM.ArrSprites(1) = MegamanRun
        MM.ArrSprites(2) = MegamanRunStart
        MM.ArrSprites(3) = MegamanMagnetStart
        MM.ArrSprites(4) = MegamanMagnetHit

        MM.PosX = 50
        MM.PosY = 172
        MM.Vx = 0
        MM.Vy = 0
        MM.State(StateMegaman.Intro, 0)
        MM.FDir = FaceDir.Right

        ListChar.Add(MM)

        bmp = New Bitmap(Img.Width, Img.Height)

        DisplayImg()
        ResizeImg()
        MM.Update()
        MC.Update()
        DisplayImg()

        Timer1.Enabled = True

    End Sub

    Sub PutSprite()
        Dim cc As CCharacter
        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg1.Elmt(i, j)
            Next
        Next
        For Each cc In ListChar
            Dim EF As CElmtFrame = cc.ArrSprites(cc.IdxArrSprites).Elmt(cc.FrameIdx)
            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top
            Dim ImgX, ImgY As Integer

            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                        End If
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                        End If
                    Next
                Next
            ElseIf cc.FDir = FaceDir.Right Then 'facing right
                Dim spriteleft = cc.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                        End If
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
                        End If
                    Next
                Next
            Else
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Bottom
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top - j))
                        End If
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        ImgX = spriteleft + i
                        ImgY = spritetop + j
                        If ImgX >= 0 And ImgX <= Img.Width - 1 And ImgY >= 0 And ImgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top - j))
                        End If
                    Next
                Next
            End If
        Next

    End Sub

    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSprite()
        'PutSprite(MM)

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next

        PictureBox1.Refresh()
        PictureBox1.Image = bmp
        PictureBox1.Width = bmp.Width
        PictureBox1.Height = bmp.Height
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        'Me.Width = PictureBox1.Width + 30
        'Me.Height = PictureBox1.Height + 100
    End Sub

    Sub ResizeImg()
        Dim w, h As Integer
        w = PictureBox1.Width
        h = PictureBox1.Height
        Me.ClientSize = New Size(w, h)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Refresh()
        Collision = CollisionDetect(MC.ArrSprites(MC.IdxArrSprites).Elmt(MC.FrameIdx), MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), MC, MM)
        If Collision Then
            'TODO list state megaman get hit
        End If

        For Each CC In ListChar
            CC.Update()
        Next

        If (MC.CurrState = StateMagnaCenti.Tail Or MC.CurrState = StateMagnaCenti.TailUD) And MC.FrameIdx = 7 Then
            CreateMagnaSeparateTail(1)
            CreateMagnaSeparateTail(2)
            CreateMagnaSeparateTail(3)
            CreateMagnaSeparateTail(4)
        ElseIf (MC.CurrState = StateMagnaCenti.Tail Or MC.CurrState = StateMagnaCenti.TailUD) And MC.FrameIdx = 11 Then
            CreateMagnaHomingTail(1)
            CreateMagnaHomingTail(2)
        End If

        If MC.CurrState = StateMagnaCenti.Throwing And MC.CurrFrame = 3 Then
            CreateMagnaProjectile(1)
        ElseIf MC.CurrState = StateMagnaCenti.Throwing And MC.CurrFrame = 5 Then
            CreateMagnaProjectile(2)
        ElseIf MC.CurrState = StateMagnaCenti.Throwing And MC.CurrFrame = 7 Then
            CreateMagnaProjectile(3)
        End If

        If MC.PosY = 158 Then
            If Math.Round(MM.PosX) = MC.PosX - 20 Then
                MC.State(StateMagnaCenti.Vanish, 8)
                resultrand = Randomizer.Next(1, 5)
                If resultrand = 5 Then
                    resultrand = Randomizer.Next(1, 5)
                End If
                MC.CurrPos = resultrand
            ElseIf Math.Round(MM.PosX) = MC.PosX + 20 Then
                MC.State(StateMagnaCenti.Vanish, 8)
                resultrand = Randomizer.Next(1, 5)
                If resultrand = 5 Then
                    resultrand = Randomizer.Next(1, 5)
                End If
                MC.CurrPos = resultrand
            End If
        End If
        'If MC.CurrState = StateMagnaCenti.Tail And MC.CurrFrame = 1 Then
        '    CreateMagnaHomingTail(1)
        'End If

        Dim Listchar1 As New List(Of CCharacter)
        For Each CC In ListChar
            If Not CC.Destroy Then
                Listchar1.Add(CC)
            End If
        Next
        ListChar = Listchar1
        'MM.Update()
        DisplayImg()
    End Sub

    Sub CreateMagnaProjectile(n As Integer)
        Dim MP As CCharMagnaProjectile

        MP = New CCharMagnaProjectile
        If MC.FDir = FaceDir.Left Then
            MP.PosX = MC.PosX
        Else
            MP.PosX = MC.PosX
        End If

        MP.PosY = MC.PosY - 3
        MP.CurrState = StateMagnaProjectile.ShurikenStart
        ReDim MP.ArrSprites(1)
        If n = 1 Then
            MP.Vx = 0
            MP.Vy = -7
            MP.ArrSprites(0) = ShurikenStart1
        ElseIf n = 2 Then
            MP.Vx = 0
            MP.Vy = -6
            MP.ArrSprites(0) = ShurikenStart2
        Else
            MP.Vx = 0
            MP.Vy = -6
            MP.ArrSprites(0) = ShurikenStart3
        End If

        MP.ArrSprites(1) = Shuriken

        ListChar.Add(MP)
    End Sub
    Sub CreateMagnaSeparateTail(n As Integer)
        Dim MS As CCharMagnaSeparate

        MS = New CCharMagnaSeparate

        MS.PosX = MC.PosX
        MS.CurrState = StateMagnaSeparate.Tail1
        ReDim MS.ArrSprites(1)
        If n = 1 Then
            MS.PosY = MC.PosY - 10
            MS.Vx = 0
            MS.Vy = 30
            MS.ArrSprites(0) = MagnaPartTail
        ElseIf n = 2 Then
            MS.PosY = MC.PosY - 15
            MS.Vx = -30
            MS.Vy = 0
            MS.ArrSprites(0) = MagnaPartTail
        ElseIf n = 3 Then
            MS.PosY = MC.PosY - 20
            MS.Vx = 30
            MS.Vy = 0
            MS.ArrSprites(0) = MagnaPartTail
        ElseIf n = 4 Then
            MS.PosY = MC.PosY - 25
            MS.Vx = 0
            MS.Vy = -30
            MS.ArrSprites(0) = MagnaPartTail
        ElseIf n = 5 Then
            MS.PosX = MM.PosX + 3
            MS.PosY = 225
            MS.ArrSprites(0) = MagnaPartTail
        End If
        ListChar.Add(MS)
    End Sub

    Sub CreateMagnaHomingTail(n As Integer)
        Dim MT As CCharMagnaHomingTail

        MT = New CCharMagnaHomingTail
        If MM.FDir = FaceDir.Left Then
            MT.PosX = MM.PosX + 40
            MT.FDir = FaceDir.Left
        Else
            MT.PosX = MM.PosX + 40
            MT.FDir = FaceDir.Right
        End If

        MT.PosY = MM.PosY - 3
        MT.Vx = MM.Vx
        MT.Vy = MM.Vy
        ReDim MT.ArrSprites(1)
        If n = 1 Then
            MT.CurrState = StateMagnaHomingTail.Tail
            MT.PosX = MM.PosX + 40
            MT.dir = 90 * Math.PI / 180
            MT.ArrSprites(0) = MagnaPartTail
        ElseIf n = 2 Then
            MT.CurrState = StateMagnaHomingTail.Tail2
            MT.PosX = MM.PosX - 20
            MT.dir = 270 * Math.PI / 180
            MT.ArrSprites(0) = MagnaPartTail
        End If
        MT.ArrSprites(1) = MagnaPartTail1
        ListChar.Add(MT)
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If MC.CurrState = StateMagnaCenti.Stand Or MC.CurrState = StateMagnaCenti.StandUD Then
            If e.KeyChar = ChrW(Keys.V) Or e.KeyChar = Char.ToLower(ChrW(Keys.V)) Then
                If MC.PosY = 158 Then
                    MC.State(StateMagnaCenti.Vanish, 8)
                    resultrand = Randomizer.Next(1, 5)
                    If resultrand = 5 Then
                        resultrand = Randomizer.Next(1, 5)
                    End If
                    MC.CurrPos = resultrand
                ElseIf MC.PosY = 65 Then
                    MC.State(StateMagnaCenti.VanishUD, 15)
                    resultrand = Randomizer.Next(1, 5)
                    If resultrand = 5 Then
                        resultrand = Randomizer.Next(1, 5)
                    End If
                    MC.CurrPos = resultrand
                End If
                'MsgBox(MC.CurrPos)
            ElseIf e.KeyChar = ChrW(Keys.S) Or e.KeyChar = Char.ToLower(ChrW(Keys.S)) Then
                MC.State(StateMagnaCenti.Throwing, 5)
                CreateMagnaProjectile(3)
            ElseIf e.KeyChar = ChrW(Keys.M) Or e.KeyChar = Char.ToLower(ChrW(Keys.M)) Then
                MC.State(StateMagnaCenti.MagnetUD, 13)
                MM.State(StateMegaman.MagnetStart, 3)
            ElseIf e.KeyChar = ChrW(Keys.T) Or e.KeyChar = Char.ToLower(ChrW(Keys.T)) Then
                If MC.PosX = 50 And MC.PosY = 158 Then
                    MC.State(StateMagnaCenti.Tail, 7)
                    MC.FDir = FaceDir.Right
                ElseIf MC.PosX = 200 And MC.PosY = 158 Then
                    MC.State(StateMagnaCenti.Tail, 7)
                    MC.FDir = FaceDir.Left
                ElseIf MC.PosX = 205 And MC.PosY = 65 Then
                    MC.State(StateMagnaCenti.TailUD, 14)
                    MC.FDir = FaceDir.Left
                ElseIf MC.PosX = 50 And MC.PosY = 65 Then
                    MC.State(StateMagnaCenti.TailUD, 14)
                    MC.FDir = FaceDir.Right
                End If

            ElseIf e.KeyChar = ChrW(Keys.J) Or e.KeyChar = Char.ToLower(ChrW(Keys.J)) Then
                If MC.PosX = 50 And MC.PosY = 158 Then
                    MC.State(StateMagnaCenti.Jump1, 2)
                    MC.Vx = 4
                    MC.Vy = 1
                    MC.FDir = FaceDir.Left
                ElseIf MC.PosX = 200 And MC.PosY = 158 Then
                    MC.State(StateMagnaCenti.Jump2, 2)
                    MC.Vx = 4
                    MC.Vy = 1
                    MC.FDir = FaceDir.Right
                ElseIf MC.PosX = 205 And MC.PosY = 65 Then
                    MC.State(StateMagnaCenti.JumpUD1, 11)
                    MC.Vx = 4
                    MC.Vy = -1
                    MC.FDir = FaceDir.Right
                ElseIf MC.PosX = 50 And MC.PosY = 65 Then
                    MC.State(StateMagnaCenti.JumpUD2, 11)
                    MC.Vx = 4
                    MC.Vy = -1
                    MC.FDir = FaceDir.Left
                End If
            ElseIf e.KeyChar = ChrW(Keys.A) Or e.KeyChar = Char.ToLower(ChrW(Keys.A)) Then
                MC.FDir = FaceDir.Left
            ElseIf e.KeyChar = ChrW(Keys.D) Or e.KeyChar = Char.ToLower(ChrW(Keys.D)) Then
                MC.FDir = FaceDir.Right
            ElseIf e.KeyChar = ChrW(Keys.Q) Or e.KeyChar = Char.ToLower(ChrW(Keys.Q)) Then
                'Test key for experiment
                CreateMagnaHomingTail(1)
                CreateMagnaHomingTail(2)
                'CreateMagnaSeparateTail(1)
                'CreateMagnaSeparateTail(2)
                'CreateMagnaSeparateTail(3)
                'CreateMagnaSeparateTail(4)
                'CreateMagnaSeparateTail(5)
                'ElseIf e.KeyChar = ChrW(Keys.Right) And e.KeyChar = ChrW(Keys.Up) Then
                'jump to ceiling
                'ElseIf e.KeyChar = ChrW(Keys.Left) And e.KeyChar = ChrW(Keys.Up) Then
                'jump to ceiling
                'ElseIf e.KeyChar = Char.ToLower(ChrW(Keys.A)) Then
                'MsgBox("Key a")
            End If
        Else
            MsgBox("Animation Not Finished")
        End If
    End Sub

    Public Function CollisionDetect(frame1 As CElmtFrame, frame2 As CElmtFrame, object1 As CCharMagna, object2 As CCharMegaMan)
        Dim L1, L2, R1, R2, T1, T2, B1, B2 As Integer

        L1 = frame1.Left - frame1.CtrPoint.x + object1.PosX
        R1 = frame1.Right - frame1.CtrPoint.x + object1.PosX
        T1 = frame1.Top - frame1.CtrPoint.y + object1.PosY
        B1 = frame1.Bottom - frame1.CtrPoint.y + object1.PosY

        L2 = frame2.Left - frame2.CtrPoint.x + object2.PosX + 30
        R2 = frame2.Right - frame2.CtrPoint.x + object2.PosX - 30
        T2 = frame2.Top - frame2.CtrPoint.y + object2.PosY + 30
        B2 = frame2.Bottom - frame2.CtrPoint.y + object2.PosY - 30

        If L2 < R1 And L1 < R2 And T1 < B2 And T2 < B1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class