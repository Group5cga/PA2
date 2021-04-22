Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
    Dim SpriteMask As CImage
    Dim MagnaStand, MagnaJump, MagnaIntro, MushroomJumpEnd As CArrFrame
    Dim SM As CCharacter

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'open image for background, assign to bg

        Bg = New CImage
        Bg.OpenImage("C:\Users\user\Documents\GitHub\PA2\Image\094.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage("C:\Users\user\Documents\GitHub\PA2\Image\MCSpritesheet.bmp")

        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        MagnaIntro = New CArrFrame
        MagnaIntro.Insert(33, 127, 6, 90, 62, 163, 1)
        MagnaIntro.Insert(91, 127, 67, 90, 115, 163, 1)
        MagnaIntro.Insert(146, 127, 120, 90, 171, 163, 1)
        MagnaIntro.Insert(201, 127, 177, 90, 223, 163, 1)
        MagnaIntro.Insert(253, 127, 229, 90, 276, 163, 1)
        MagnaIntro.Insert(305, 127, 281, 90, 328, 163, 1)

        MagnaStand = New CArrFrame

        MagnaStand.Insert(1884, 158, 1790, 38, 1978, 279, 1)
        MagnaStand.Insert(2100, 158, 2005, 38, 2194, 279, 1)
        MagnaStand.Insert(2305, 158, 2206, 38, 2401, 279, 1)
        MagnaStand.Insert(2517, 158, 2417, 38, 2613, 279, 1)

        MagnaJump = New CArrFrame
        MagnaJump.Insert(38, 218, 12, 186, 62, 250, 1)
        MagnaJump.Insert(93, 219, 66, 186, 117, 250, 1)
        MagnaJump.Insert(148, 218, 125, 186, 172, 250, 1)
        MagnaJump.Insert(206, 218, 176, 186, 234, 250, 1)
        MagnaJump.Insert(259, 216, 238, 187, 343, 250, 1)
        MagnaJump.Insert(314, 218, 284, 186, 343, 250, 1)
        MagnaJump.Insert(370, 219, 352, 186, 386, 250, 1)
        MagnaJump.Insert(409, 218, 391, 186, 427, 250, 1)

        MushroomJump = New CArrFrame
        MushroomJump.Insert(538, 33, 514, 7, 566, 60, 1)

        MushroomJumpEnd = New CArrFrame
        MushroomJumpEnd.Insert(55, 170, 33, 144, 80, 191, 1)
        MushroomJumpEnd.Insert(481, 42, 455, 23, 508, 63, 3)
        MushroomJumpEnd.Insert(55, 170, 33, 144, 80, 191, 2)
        MushroomJumpEnd.Insert(113, 170, 91, 144, 131, 191, 1)

        SM = New CCharacter
        ReDim SM.ArrSprites(3)
        SM.ArrSprites(0) = MagnaIntro
        SM.ArrSprites(1) = MagnaStand
        SM.ArrSprites(2) = MagnaJump
        SM.ArrSprites(3) = MushroomJumpEnd

        SM.PosX = 300
        SM.PosY = 200
        SM.Vx = -5
        SM.Vy = 0
        SM.State(StateSplitMushroom.Walk, 0)
        SM.FDir = FaceDir.Left

        bmp = New Bitmap(Img.Width, Img.Height)

        DisplayImg()
        ResizeImg()

        Timer1.Enabled = False
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
        PutSprite(SM)

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
        SM.Update()
        DisplayImg()
    End Sub
End Class