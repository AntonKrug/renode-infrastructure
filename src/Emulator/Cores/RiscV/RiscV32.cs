//
// Copyright (c) 2010-2018 Antmicro
//
// This file is licensed under the MIT License.
// Full license text is available in 'licenses/MIT.txt'.
//
using Antmicro.Renode.Core;
using Antmicro.Renode.Peripherals.Timers;
using Endianess = ELFSharp.ELF.Endianess;

namespace Antmicro.Renode.Peripherals.CPU
{
    public partial class RiscV32 : BaseRiscV
    {
        public RiscV32(IRiscVTimeProvider timeProvider, string cpuType, Machine machine, uint hartId = 0, PrivilegeArchitecture privilegeArchitecture = PrivilegeArchitecture.Priv1_10, Endianess endianness = Endianess.LittleEndian, uint? nmiVectAddr = null, uint? nmiVectLen = null)
                : base(timeProvider, hartId, cpuType, machine, privilegeArchitecture, endianness, CpuBitness.Bits32, nmiVectAddr, nmiVectLen)
        {
        }

        public override string Architecture { get { return "riscv"; } }

        public override string GDBArchitecture { get { return "riscv:rv32"; } }

        private uint BeforePCWrite(uint value)
        {
            PCWritten();
            return value;
        }
    }
}

