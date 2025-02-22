using System;

[Flags]
public enum SkinCategory
{
    None = (0),
    Bath = (1 << 0),
    Spoiler = (1 << 1),
    ExhaustPipe = (1 << 2),
    Wheels = (1 << 3),
    Character = (1 << 4),
    HeadAccessory = (1 << 5),
    Parachute = (1 << 6),
    Horn = (1 << 7),
    ExhaustPipeVfx = (1 << 8),
}
