Imports System.IO
Public Enum StateMagnaCenti
    Intro
    Stand
    Jump1
    Jump2
    Hit
    Dead
    Throwing
    Magnet
    Tail
    Vanish
    Appear
    StandUD
    JumpUD1
    JumpUD2
    ThrowingUD
    MagnetUD
    TailUD
    VanishUD
    AppearUD
End Enum
Public Enum StateMegaman
    RunStart
    Run
    Intro
    MagnetStart
    MagnetHit
    MagnetGoing
    Hit
End Enum
Public Enum StateMagnaProjectile
    ShurikenStart
    Shuriken1
    Tail
End Enum
Public Enum StateMagnaSeparate
    Tailstart
    Tail1
    Tail2
    Tail3
    Tail4
    Tail5
    Tail6
End Enum
Public Enum StateMagnaHomingTail
    Tail
    Tail2
End Enum
Public Enum FaceDir
    Left
    Right
    Up
    Down
End Enum
Public Class CImage
    Public Width As Integer
    Public Height As Integer
    Public Elmt(,) As System.Drawing.Color
    Public ColorMode As Integer 'not used

    Sub OpenImage(ByVal FName As String)
        Dim s As String
        Dim L As Long
        Dim BR As BinaryReader
        Dim h, w, pos As Integer
        Dim r, g, b As Integer
        Dim pad As Integer

        BR = New BinaryReader(File.Open(FName, FileMode.Open))

        Try
            BlockRead(BR, 2, s)

            If s <> "BM" Then
                MsgBox("Not a BMP file")
            Else 'BMP file
                BlockReadInt(BR, 4, L) 'size
                BlankRead(BR, 4) 'reserved
                BlockReadInt(BR, 4, pos) 'start of data
                BlankRead(BR, 4) 'size of header
                BlockReadInt(BR, 4, Width) 'width
                BlockReadInt(BR, 4, Height) 'height
                BlankRead(BR, 2) 'color panels
                BlockReadInt(BR, 2, ColorMode) 'colormode
                If ColorMode <> 24 Then
                    MsgBox("Not a 24-bit color BMP")
                Else
                    BlankRead(BR, pos - 30)

                    ReDim Elmt(Width - 1, Height - 1)
                    pad = (4 - (Width * 3 Mod 4)) Mod 4

                    For h = Height - 1 To 0 Step -1
                        For w = 0 To Width - 1
                            BlockReadInt(BR, 1, b)
                            BlockReadInt(BR, 1, g)
                            BlockReadInt(BR, 1, r)
                            Elmt(w, h) = Color.FromArgb(r, g, b)
                        Next
                        BlankRead(BR, pad)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox("Error")
        End Try
        BR.Close()
    End Sub
    Sub CreateMask(ByRef Mask As CImage)
        Dim i, j As Integer

        Mask = New CImage
        Mask.Width = Width
        Mask.Height = Height

        ReDim Mask.Elmt(Mask.Width - 1, Mask.Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                If Elmt(i, j).R = 0 And Elmt(i, j).G = 0 And Elmt(i, j).B = 0 Then
                    Mask.Elmt(i, j) = Color.FromArgb(255, 255, 255)
                Else
                    Mask.Elmt(i, j) = Color.FromArgb(0, 0, 0)
                End If
            Next
        Next
    End Sub
    Sub CopyImg(ByRef Img As CImage)
        'copies image to Img
        Img = New CImage
        Img.Width = Width
        Img.Height = Height
        ReDim Img.Elmt(Width - 1, Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                Img.Elmt(i, j) = Elmt(i, j)
            Next
        Next
    End Sub
End Class
Public Class CCharacter
    Public PosX, PosY, DestX, DestY, Dist As Double
    Public Vx, Vy, V As Double
    Public FrameIdx As Integer
    Public CurrFrame As Integer
    Public ArrSprites() As CArrFrame
    Public IdxArrSprites As Integer
    Public FDir As FaceDir
    Public dir, dir2, turnrate As Double
    Public CurrPos As Integer
    Public Destroy As Boolean = False
    Public dx, dy, z As Double
    Public countdown As Integer

    Public Sub RandomPos(CurrPos)
        Select Case CurrPos
            Case 1
                PosX = 50
                PosY = 65
                FDir = FaceDir.Right
            Case 2
                PosX = 205
                PosY = 65
                FDir = FaceDir.Left
            Case 3
                PosX = 50
                PosY = 158
                FDir = FaceDir.Right
            Case 4
                PosX = 200
                PosY = 158
                FDir = FaceDir.Left
        End Select
    End Sub

    Public Sub GetNextFrame()
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                FrameIdx = 0
            End If
            CurrFrame = 0
        End If
    End Sub

    Public Overridable Sub Update()

    End Sub
End Class
Public Class CCharMagna
    Inherits CCharacter
    Public CurrState As StateMagnaCenti
    Public Sub State(state As StateMagnaCenti, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMagnaCenti.Intro
                GetNextFrame()
                If FrameIdx = 15 And CurrFrame = 1 Then
                    State(StateMagnaCenti.Stand, 1)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.Stand
                If FrameIdx <= 4 Then
                    GetNextFrame()
                End If

            Case StateMagnaCenti.StandUD
                If FrameIdx <= 4 Then
                    GetNextFrame()
                End If

            Case StateMagnaCenti.Jump1
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                Vy = Vy - 0.2
                If PosY <= 65 And Vy < 0 Then
                    State(StateMagnaCenti.StandUD, 10)
                    RandomPos(2)
                    Vx = 0
                    Vy = 0
                End If

            Case StateMagnaCenti.Jump2
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY + Vy
                Vy = Vy - 0.2
                If PosY <= 65 And Vy < 0 Then
                    State(StateMagnaCenti.StandUD, 10)
                    RandomPos(1)
                    Vx = 0
                    Vy = 0
                End If

            Case StateMagnaCenti.JumpUD1
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY + Vy
                Vy = Vy + 0.2
                If PosY >= 158 And Vy > 0 Then
                    State(StateMagnaCenti.Stand, 1)
                    RandomPos(3)
                    Vx = 0
                    Vy = 0
                End If

            Case StateMagnaCenti.JumpUD2
                GetNextFrame()
                PosX = PosX + Vx
                PosY = PosY + Vy
                Vy = Vy + 0.2
                If PosY >= 158 And Vy > 0 Then
                    State(StateMagnaCenti.Stand, 1)
                    RandomPos(4)
                    Vx = 0
                    Vy = 0
                End If

            Case StateMagnaCenti.Dead
                If FrameIdx <= 2 Then
                    GetNextFrame()
                End If
            Case StateMagnaCenti.MagnetUD
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMagnaCenti.StandUD, 10)
                End If

            Case StateMagnaCenti.Tail
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMagnaCenti.Stand, 1)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.TailUD
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMagnaCenti.StandUD, 10)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.Throwing
                GetNextFrame()
                If FrameIdx = 4 And CurrFrame = 3 Then
                    State(StateMagnaCenti.Stand, 1)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.ThrowingUD
                GetNextFrame()
                If FrameIdx = 4 And CurrFrame = 3 Then
                    State(StateMagnaCenti.StandUD, 10)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.Vanish
                GetNextFrame()
                If FrameIdx = 5 And CurrFrame = 2 And CurrPos <= 2 Then
                    State(StateMagnaCenti.AppearUD, 16)
                    Vx = 0
                    Vy = 0
                ElseIf FrameIdx = 5 And CurrFrame = 2 And CurrPos >= 3 Then
                    State(StateMagnaCenti.Appear, 9)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.VanishUD
                GetNextFrame()
                If FrameIdx = 5 And CurrFrame = 2 And CurrPos <= 2 Then
                    State(StateMagnaCenti.AppearUD, 16)
                    Vx = 0
                    Vy = 0
                ElseIf FrameIdx = 5 And CurrFrame = 2 And CurrPos >= 3 Then
                    State(StateMagnaCenti.Appear, 9)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.Appear
                GetNextFrame()
                RandomPos(CurrPos)
                If FrameIdx = 5 And CurrFrame = 3 Then
                    State(StateMagnaCenti.Stand, 1)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.AppearUD
                GetNextFrame()
                RandomPos(CurrPos)
                If FrameIdx = 5 And CurrFrame = 3 Then
                    State(StateMagnaCenti.StandUD, 10)
                    Vx = 0
                    Vy = 0
                End If
            Case StateMagnaCenti.Hit
                GetNextFrame()
                If FrameIdx = 1 And CurrFrame = 9 Then
                    State(StateMagnaCenti.Stand, 1)
                    Vx = 0
                    Vy = 0
                End If
        End Select
    End Sub
End Class
Public Class CCharMegaMan
    Inherits CCharacter
    Public CurrState As StateMegaman
    Public Sub State(state As StateMegaman, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMegaman.Intro
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMegaman.RunStart, 2)
                End If
            Case StateMegaman.RunStart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMegaman.Run, 1)
                End If
            Case StateMegaman.Run
                GetNextFrame()
                PosX = PosX + Vx
                If PosX <= 50 Then
                    PosX = PosX + Vx
                    Vx = Vx + 0.2
                    FDir = FaceDir.Left
                End If
                If PosX >= 200 Then
                    Vx = Vx - 0.2
                    FDir = FaceDir.Right
                End If
            Case StateMegaman.MagnetStart
                GetNextFrame()
                If FrameIdx <= 5 Then
                    Vx = V * Math.Cos(dir)
                    Vy = V * Math.Sin(dir)
                    dx = DestX - PosX
                    dy = DestY - PosY
                    z = Vx * dy - Vy * dx
                    If z >= 0 Then 'turn left
                        dir = dir + turnrate
                    Else 'turn right
                        dir = dir - turnrate
                    End If
                    Vx = V * Math.Cos(dir)
                    Vy = V * Math.Sin(dir)
                    PosX = PosX + Vx
                    PosY = PosY + Vy
                    Dist = (DestX - PosX) * (DestX - PosX) + (DestY - PosY) * (DestY - PosY)
                    If Dist <= 100 Then
                        Vx = 0
                        Vy = 0
                        State(StateMegaman.MagnetGoing, 4)
                    End If
                End If
            Case StateMegaman.MagnetGoing
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMegaman.MagnetHit, 3)
                End If
            Case StateMegaman.Hit
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    Destroy = True
                    countdown = 30
                End If
            Case StateMegaman.MagnetHit
                GetNextFrame()
                If FrameIdx <= 6 And PosX <= 160 Then
                    PosY = PosY + Vy
                    Vy = Vy + 1
                    If PosY >= 172 Then
                        State(StateMegaman.Intro, 0)
                        PosX = 40
                        PosY = 172
                        Vx = 0
                        Vy = 0
                    End If
                ElseIf FrameIdx <= 6 And PosX >= 160 Then
                    PosY = PosY + Vy
                    Vy = Vy + 1
                    If PosY >= 172 Then
                        State(StateMegaman.Intro, 0)
                        PosX = 205
                        PosY = 172
                        Vx = 0
                        Vy = 0
                    End If
                End If
        End Select
    End Sub
End Class
Public Class CCharMagnaProjectile
    Inherits CCharacter

    Public CurrState As StateMagnaProjectile

    Public Sub State(state As StateMagnaProjectile, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0

    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMagnaProjectile.ShurikenStart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMagnaProjectile.Shuriken1, 1)
                End If
            Case StateMagnaProjectile.Shuriken1
                GetNextFrame()
                If PosY <= 200 Then
                    PosX = PosX - Vx
                    PosY = PosY + Vy
                    Vy = Vy + 0.5
                    Vx = Vx + 0.3
                Else
                    Destroy = True
                End If
            Case StateMagnaProjectile.Tail
                GetNextFrame()
                If PosX <= 220 Then
                    'update dir
                    dir = dir + 1 * Math.PI / 180

                    'update v
                    Vx = Math.Cos(dir)
                    Vy = Math.Sin(dir)

                    'update pos
                    PosX = PosX + Vx
                    PosY = PosY + Vy
                Else
                    Destroy = True
                End If
        End Select
    End Sub

End Class
Public Class CCharMagnaHomingTail
    Inherits CCharacter

    Public CurrState As StateMagnaHomingTail

    Public Sub State(state As StateMagnaHomingTail, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0

    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMagnaHomingTail.Tail
                GetNextFrame()
                If dir <= 720 * Math.PI / 180 Then
                    dir = dir + 8 * Math.PI / 180
                    'update v
                    Vx = 4 * Math.Cos(dir)
                    Vy = 4 * Math.Sin(dir)
                    'update pos
                    PosX = PosX + Vx
                    PosY = PosY + Vy
                ElseIf dir >= 720 * Math.PI / 180 Then
                    Vx = 0
                    Vy = Vy - (Vy - 4)
                    PosX = PosX + Vx
                    PosY = PosY + Vy
                    If PosY >= 172 Then
                        Destroy = True
                    End If
                Else
                    Destroy = True
                End If
            Case StateMagnaHomingTail.Tail2
                GetNextFrame()
                If dir <= 900 * Math.PI / 180 Then
                    dir = dir + 8 * Math.PI / 180
                    'update v
                    Vx = 4 * Math.Cos(dir)
                    Vy = 4 * Math.Sin(dir)
                    'update pos
                    PosX = PosX + Vx
                    PosY = PosY + Vy
                ElseIf dir >= 900 * Math.PI / 180 Then
                    Vx = 0
                    Vy = 4
                    PosX = PosX + Vx
                    PosY = PosY - Vy
                    If PosY <= 172 Then
                        Destroy = True
                    End If
                Else
                    Destroy = True
                End If
        End Select
    End Sub

End Class
Public Class CCharMagnaSeparate
    Inherits CCharacter

    Public CurrState As StateMagnaSeparate

    Public Sub State(state As StateMagnaSeparate, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0

    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMagnaSeparate.Tailstart
                GetNextFrame()
                If FrameIdx = 0 And CurrFrame = 0 Then
                    State(StateMagnaSeparate.Tail1, 1)
                End If
            Case StateMagnaSeparate.Tail1
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If PosX < 0 Or PosX > 260 Or PosY = 165 Then
                    Destroy = True
                End If
            Case StateMagnaSeparate.Tail2
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If (PosY > 150 And PosY < 160) Then
                    Destroy = True
                End If
                If (PosX > 190 And PosX < 205) Then
                    Destroy = True
                End If
            Case StateMagnaSeparate.Tail3
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If PosY < 165 Then
                    Destroy = True
                End If
            Case StateMagnaSeparate.Tail4
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If (PosY > 60 And PosY < 70) Then
                    Destroy = True
                End If
                If (PosX > 40 And PosX < 60) Then
                    Destroy = True
                End If
            Case StateMagnaSeparate.Tail5
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If (PosX > 195 And PosX < 210) Then
                    Destroy = True
                End If
                If (PosY > 60 And PosY < 70) Then
                    Destroy = True
                End If
            Case StateMagnaSeparate.Tail6
                GetNextFrame()
                PosX = PosX - Vx
                PosY = PosY - Vy
                If (PosX > 40 And PosX < 60) Then
                    Destroy = True
                End If
                If (PosY > 150 And PosY < 160) Then
                    Destroy = True
                End If
        End Select
    End Sub

End Class
Public Class CElmtFrame
    Public CtrPoint As TPoint
    Public Top, Bottom, Left, Right As Integer
    Public Idx As Integer
    Public MaxFrameTime As Integer

    Public Sub New(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        CtrPoint.x = ctrx
        CtrPoint.y = ctry
        Top = t
        Bottom = b
        Left = l
        Right = r
        MaxFrameTime = mft

    End Sub
End Class
Public Class CArrFrame
    Public N As Integer
    Public Elmt As CElmtFrame()

    Public Sub New()
        N = 0
        ReDim Elmt(-1)
    End Sub

    Public Overloads Sub Insert(E As CElmtFrame)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1
    End Sub

    Public Overloads Sub Insert(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        Dim E As CElmtFrame
        E = New CElmtFrame(ctrx, ctry, l, t, r, b, mft)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1
    End Sub
End Class
Public Structure TPoint
    Dim x As Integer
    Dim y As Integer
End Structure