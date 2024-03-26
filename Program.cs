using CS2HizOlcer;
using Swed64;
using System.Diagnostics;
using System;
using System.Numerics;

System.Diagnostics.Process.Start(new ProcessStartInfo
{
    FileName = "https://discord.gg/taDUKGdxJK",
    UseShellExecute = true
});

Swed swed = new Swed("cs2");

IntPtr client = swed.GetModuleBase("client.dll");

Renderer renderer = new Renderer();
Thread renderThread = new Thread(new ThreadStart(renderer.Start().Wait));
renderThread.Start();

int dwLocalPlayerPawn = 0x17371A8; //https://github.com/a2x/cs2-dumper

int m_vecAbsVelocity = 0x3D8; //https://github.com/a2x/cs2-dumper

while (true)
{
    IntPtr localPlayerPawn = swed.ReadPointer(client, dwLocalPlayerPawn);

    Vector3 velocity = swed.ReadVec(localPlayerPawn, m_vecAbsVelocity);

    int speed = (int)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y + velocity.Z * velocity.Z);

    renderer.speed = speed;
}