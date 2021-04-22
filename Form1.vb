Imports System.IO

Public Class Form1

    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage
    Dim SpriteMap As CImage
    Dim SpriteMask As CImage
    Dim MushroomRun, MushroomJumpStart, MushroomJump, MushroomJumpEnd As CArrFrame
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
        MushroomRun = New CArrFrame

        MushroomRun.Insert(175, 170, 156, 144, 194, 191, 1)
        MushroomRun.Insert(223, 170, 202, 144, 251, 190, 1)
        MushroomRun.Insert(279, 170, 260, 144, 300, 192, 1)
        MushroomRun.Insert(322, 170, 304, 146, 339, 192, 1)
        MushroomRun.Insert(362, 169, 343, 143, 385, 191, 1)
        MushroomRun.Insert(411, 170, 391, 146, 440, 189, 1)
        MushroomRun.Insert(463, 169, 446, 144, 484, 193, 1)
        MushroomRun.Insert(510, 170, 492, 146, 526, 192, 1)

        MushroomJumpStart = New CArrFrame
        MushroomJumpStart.Insert(113, 170, 91, 144, 131, 191, 1)
        MushroomJumpStart.Insert(55, 170, 33, 144, 80, 191, 2)
        MushroomJumpStart.Insert(538, 33, 514, 7, 566, 60, 1)

        MushroomJump = New CArrFrame
        MushroomJump.Insert(538, 33, 514, 7, 566, 60, 1)

        MushroomJumpEnd = New CArrFrame
        MushroomJumpEnd.Insert(55, 170, 33, 144, 80, 191, 1)
        MushroomJumpEnd.Insert(481, 42, 455, 23, 508, 63, 3)
        MushroomJumpEnd.Insert(55, 170, 33, 144, 80, 191, 2)
        MushroomJumpEnd.Insert(113, 170, 91, 144, 131, 191, 1)

        SM = New CCharacter
        ReDim SM.ArrSprites(3)
        SM.ArrSprites(0) = MushroomRun
        SM.ArrSprites(1) = MushroomJumpStart
        SM.ArrSprites(2) = MushroomJump
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