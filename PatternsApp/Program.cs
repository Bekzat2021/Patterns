using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Monitor monitor = new Monitor();
            IHDMI HDMI_Cable = new HDMICable();
            monitor.Display(HDMI_Cable);
            
            IVGA vga = new VGACable();
            VGA_To_HDMI_Adapter adaptedVgaCable = new VGA_To_HDMI_Adapter(vga);
            monitor.Display(adaptedVgaCable);
        }
    }

    interface IHDMI
    {
        void TransferDataFast();
    }

    class HDMICable : IHDMI
    {
        public void TransferDataFast()
        {
            Console.WriteLine("HDMI cable transfer data fast");
        }
    }

    class Monitor
    {
        public void Display(IHDMI hdmi)
        {
            hdmi.TransferDataFast();
        }
    }

    interface IVGA
    {
        void TransferDataSlow();
    }

    class VGACable : IVGA
    {
        public void TransferDataSlow()
        {
            Console.WriteLine("VGA cable transfer data slow");
        }
    }

    class VGA_To_HDMI_Adapter : IHDMI
    {
        IVGA vGA;
        public VGA_To_HDMI_Adapter(IVGA vGA)
        {
            this.vGA = vGA;
        }

        public void TransferDataFast()
        {
            vGA.TransferDataSlow();
        }
    }
}
