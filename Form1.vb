Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap, SpriteMap2 As CImage
    Dim SpriteMask, SpriteMask2 As CImage
    Dim MegamanStand, MegamanRun, MagnaStand, MagnaJump, MagnaIntro, MagnaHit, MagnaDead, MagnaThrowing, MagnaMagnet, MagnaTail, MagnaVanish, MagnaAppear, MagnaPartTail, Shuriken As CArrFrame
    Dim MC, MM As CCharacter

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'open image for background, assign to bg
        Bg = New CImage
        Bg.OpenImage("Image\094.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage("Image\MCSpriteSheet2.bmp")

        SpriteMap2 = New CImage
        SpriteMap2.OpenImage("Image\MMSpriteSheet.bmp")

        SpriteMap.CreateMask(SpriteMask)
        SpriteMap2.CreateMask(SpriteMask2)

        'initialize sprites
        MegamanStand = New CArrFrame
        MegamanStand.Insert(241, 46, 224, 27, 257, 64, 1)
        MegamanStand.Insert(276, 46, 259, 27, 292, 64, 1)
        MegamanStand.Insert(310, 46, 294, 27, 326, 64, 1)
        MegamanStand.Insert(345, 46, 328, 27, 361, 64, 1)

        MegamanRun = New CArrFrame
        MegamanRun.Insert(20, 84, 3, 65, 36, 102, 1)
        MegamanRun.Insert(60, 84, 48, 65, 70, 102, 1)
        MegamanRun.Insert(87, 84, 73, 65, 100, 102, 1)
        MegamanRun.Insert(121, 84, 103, 65, 138, 103, 1)
        MegamanRun.Insert(162, 84, 143, 65, 180, 102, 1)
        MegamanRun.Insert(203, 84, 188, 65, 217, 102, 1)
        MegamanRun.Insert(233, 84, 221, 65, 245, 102, 1)
        MegamanRun.Insert(261, 84, 247, 65, 274, 102, 1)
        MegamanRun.Insert(313, 84, 278, 65, 310, 102, 1)
        MegamanRun.Insert(335, 84, 316, 65, 353, 102, 1)
        MegamanRun.Insert(373, 84, 357, 65, 389, 102, 1)

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

        MagnaJump = New CArrFrame
        MagnaJump.Insert(38, 218, 12, 186, 62, 250, 1)
        MagnaJump.Insert(93, 219, 66, 186, 117, 250, 1)
        MagnaJump.Insert(148, 218, 125, 186, 172, 250, 1)
        MagnaJump.Insert(206, 218, 176, 186, 234, 250, 1)
        MagnaJump.Insert(370, 219, 352, 186, 386, 250, 1)
        MagnaJump.Insert(409, 218, 391, 186, 427, 250, 1)
        MagnaJump.Insert(259, 216, 238, 187, 343, 250, 1)
        MagnaJump.Insert(314, 218, 284, 186, 343, 250, 1)


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

        MagnaMagnet = New CArrFrame
        MagnaMagnet.Insert(42, 455, 19, 419, 65, 492, 4)
        MagnaMagnet.Insert(92, 455, 65, 419, 119, 492, 4)
        MagnaMagnet.Insert(147, 455, 119, 419, 175, 492, 4)
        MagnaMagnet.Insert(203, 455, 175, 419, 231, 492, 4)
        MagnaMagnet.Insert(260, 455, 231, 419, 289, 492, 4)
        MagnaMagnet.Insert(316, 455, 289, 419, 343, 492, 4)

        MagnaTail = New CArrFrame
        MagnaTail.Insert(39, 298, 16, 259, 63, 335, 3)
        MagnaTail.Insert(92, 298, 67, 259, 115, 335, 3)
        MagnaTail.Insert(145, 298, 120, 259, 169, 335, 3)
        MagnaTail.Insert(197, 298, 174, 259, 220, 335, 3)
        MagnaTail.Insert(248, 298, 225, 259, 272, 335, 3)
        MagnaTail.Insert(303, 298, 276, 259, 329, 335, 3)
        MagnaTail.Insert(360, 298, 333, 259, 386, 335, 3)
        MagnaTail.Insert(417, 298, 390, 259, 444, 335, 3)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(531, 298, 505, 259, 558, 335, 2)
        MagnaTail.Insert(475, 298, 448, 259, 500, 335, 2)
        MagnaTail.Insert(587, 298, 562, 259, 612, 335, 3)

        MagnaVanish = New CArrFrame
        MagnaVanish.Insert(25, 977, 6, 947, 44, 1005, 4)
        MagnaVanish.Insert(67, 976, 47, 947, 87, 1005, 3)
        MagnaVanish.Insert(110, 976, 90, 947, 129, 1005, 3)
        MagnaVanish.Insert(110, 976, 95, 952, 124, 1000, 3)
        MagnaVanish.Insert(110, 976, 100, 957, 119, 995, 3)
        MagnaVanish.Insert(110, 976, 105, 962, 114, 990, 3)

        MagnaAppear = New CArrFrame
        MagnaAppear.Insert(110, 976, 105, 962, 114, 990, 3)
        MagnaAppear.Insert(110, 976, 100, 957, 119, 995, 3)
        MagnaAppear.Insert(110, 976, 95, 952, 124, 1000, 3)
        MagnaAppear.Insert(110, 976, 90, 947, 129, 1005, 3)
        MagnaAppear.Insert(67, 976, 47, 947, 87, 1005, 3)
        MagnaAppear.Insert(25, 977, 6, 947, 44, 1005, 4)

        MagnaPartTail = New CArrFrame
        MagnaPartTail.Insert(15, 821, 8, 814, 23, 829, 1)
        MagnaPartTail.Insert(31, 821, 23, 841, 40, 829, 1)
        MagnaPartTail.Insert(53, 824, 46, 819, 59, 830, 1)
        MagnaPartTail.Insert(15, 838, 8, 832, 23, 845, 1)
        MagnaPartTail.Insert(31, 838, 23, 721, 40, 845, 1)
        MagnaPartTail.Insert(58, 838, 48, 832, 68, 845, 1)
        MagnaPartTail.Insert(81, 838, 72, 832, 91, 845, 1)
        MagnaPartTail.Insert(107, 838, 97, 832, 117, 845, 1)

        Shuriken = New CArrFrame
        Shuriken.Insert(161, 911, 157, 908, 166, 914, 1)
        Shuriken.Insert(170, 911, 166, 908, 174, 914, 1)
        Shuriken.Insert(178, 911, 174, 908, 183, 914, 1)

        MC = New CCharacter
        ReDim MC.ArrSprites(9)
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

        'MM = New CCharacter
        'ReDim MM.ArrSprites(2)
        'MM.ArrSprites(0) = MegamanStand
        'MM.ArrSprites(1) = MegamanRun

        MC.PosX = 200
        MC.PosY = 158
        MC.Vx = 0
        MC.Vy = 0
        MC.State(StateMagnaCenti.Magnet, 0)
        MC.FDir = FaceDir.Left

        'MM.PosX = 200
        'MM.PosY = 100
        'MM.Vx = 0
        'MM.Vy = 0
        'MM.State(StateMegaman.Stand, 0)
        'MM.FDir = FaceDir.Right

        bmp = New Bitmap(Img.Width, Img.Height)

        DisplayImg()
        ResizeImg()
        'MM.Update()
        MC.Update()
        DisplayImg()

        Timer1.Enabled = True

    End Sub

    Sub PutSprite(ByVal c As CCharacter)
        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg1.Elmt(i, j)
            Next
        Next

        Dim EF As CElmtFrame = c.ArrSprites(c.IdxArrSprites).Elmt(c.FrameIdx)
        Dim spritewidth = EF.Right - EF.Left
        Dim spriteheight = EF.Bottom - EF.Top


        If c.FDir = FaceDir.Left Then
            Dim spriteleft As Integer = c.PosX - EF.CtrPoint.x + EF.Left
            Dim spritetop As Integer = c.PosY - EF.CtrPoint.y + EF.Top
            'set mask
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                Next
            Next

            'set sprite
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                Next
            Next
        Else 'facing right
            Dim spriteleft = c.PosX + EF.CtrPoint.x - EF.Right
            Dim spritetop = c.PosY - EF.CtrPoint.y + EF.Top
            'set mask
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                Next
            Next

            'set sprite
            For i = 0 To spritewidth
                For j = 0 To spriteheight
                    Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
                Next
            Next
        End If
    End Sub

    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer
        PutSprite(MC)
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
        'MM.Update()
        MC.Update()
        DisplayImg()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.V) Or e.KeyChar = Char.ToLower(ChrW(Keys.V)) Then
            MC.State(StateMagnaCenti.Vanish, 8)
        ElseIf e.KeyChar = ChrW(Keys.S) Or e.KeyChar = Char.ToLower(ChrW(Keys.S)) Then
            MC.State(StateMagnaCenti.Throwing, 5)
        ElseIf e.KeyChar = ChrW(Keys.M) Or e.KeyChar = Char.ToLower(ChrW(Keys.M)) Then
            MC.State(StateMagnaCenti.Magnet, 6)
        ElseIf e.KeyChar = ChrW(Keys.T) Or e.KeyChar = Char.ToLower(ChrW(Keys.T)) Then
            MC.State(StateMagnaCenti.Tail, 7)
        ElseIf e.KeyChar = ChrW(Keys.Up) Then
            MC.State(StateMagnaCenti.Jump, 7)
        ElseIf e.KeyChar = ChrW(Keys.Left) Then
            MC.FDir = FaceDir.Left
        ElseIf e.KeyChar = ChrW(Keys.Right) Then
            MC.FDir = FaceDir.Right
            'ElseIf e.KeyChar = ChrW(Keys.Right) And e.KeyChar = ChrW(Keys.Up) Then
            'jump to ceiling
            'ElseIf e.KeyChar = ChrW(Keys.Left) And e.KeyChar = ChrW(Keys.Up) Then
            'jump to ceiling
        ElseIf e.KeyChar = Char.ToLower(ChrW(Keys.A)) Then
            MsgBox("Key a")
        End If
    End Sub
End Class