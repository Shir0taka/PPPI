.assembly extern mscorlib {}
.assembly Lab1 {}
.module Lab1.exe

.class private auto ansi beforefieldinit Lab1.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    .maxstack  2
    .locals init (bool V_0,
             int32 V_1)
    IL_0000:  nop
    IL_0001:  ldc.i4.0
    IL_0002:  stloc.0
    IL_0003:  br.s       IL_0047
    IL_0005:  nop
    IL_0006:  ldstr      "Choose option:"
    IL_000b:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0010:  ldstr      "1. Set amount of words to show"
    IL_0015:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_001a:  ldstr      "2. Do math operations"
    IL_001f:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0024:  ldstr      "0. Exit"
    IL_0029:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_002e:  nop
    IL_002f:  call       int32 [mscorlib]System.Console::ReadLine()
    IL_0034:  call       int32::Parse(string)
    IL_0039:  stloc.1
    IL_003a:  nop
    IL_003b:  ldloc.1
    IL_003c:  ldc.i4.1
    sub
    ldc.i4.2
    switch     ( 
                IL_0062,
                IL_0086,
                IL_00a5)
    IL_0045:  br.s       IL_0003
    IL_0047:  nop
    IL_0048:  ldloc.0
    brtrue.s   IL_0005
    IL_004a:  ret
    IL_0062:  nop
    IL_0063:  ldstr      "Enter a number words:"
    IL_0068:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_006d:  call       void Lab1.Program::ShowWordsInText()
    IL_0072:  nop
    IL_0073:  br.s       IL_0047
    IL_0075:  nop
    IL_0076:  call       void Lab1.Program::DoMath()
    IL_007b:  nop
    IL_007c:  br.s       IL_0047
    IL_007e:  nop
    IL_007f:  ldc.i4.1
    stloc.0
    IL_0080:  br.s       IL_0048
    IL_0082:  nop
    IL_0083:  ldstr      "Incorrect input!"
    IL_0088:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_008d:  nop
    IL_008e:  br.s       IL_0047
    IL_0090:  nop
    IL_0091:
