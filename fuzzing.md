## Answers to Lab Exercise 3 Part 2 - SeiP 2024
Name: Evangelos Talos

### Task 1
Answer: 

Inputs that caused crash:
- ^@^@^@^`^Nl  <2  %^l  ;&!c
- ^x    ^x\^s^mC 1     ^NR  <2  %h  x&!c
- ^x   ^Nl  <2                %h ^xx&!^@

Descriptions of the inputs that cause the program to crash:
- All inputs where the first or the last character is the null character
- All inputs containing consecutive increasing digits

### Task 2
Answer:

Inputs that caused crash:
-  v R^q^Df^q^Df    w +^U *OlzO    w +^U *OlzO^U^V^\A
-  hZ   V{^H ^j   V{^H ^j ief^`^@^dl ^j iff^`^@^dl ^j^@d ^_^G+^q hhhhhhhh^g   V{^H ^j+^q^q
-  th^`gfffg^C^? ~^@^@lllll ^` ^P^`Z   4{^H^_^_^_^_^_^_^_^_^_^_^_^_^_ijjjjjjjj^C jjjjjjjjjjgffff ^G+^q
- f^@tttttll l+^q^q^E     l      #^G+^q^q^q^q^q^q^q^dt ttrftll l+^q^q^E     l       ^G+^q^q^q^q^q^q^q^d   ^?
-  thZ  ^LR{^H^}^?^?^?ffgffL^`^@^dl^Ag^j i  ^G+^m llhZ  ^LR ^C^@^@ll ll

Description of the inputs that cause the program to crash:
- Any sequence of inputs where the total number of f commands is at least two more than the number of h commands, followed by an l, will cause the program to crash. The reason is that the initial number of crew members is 2, so if we fire all the crew members, we cannot land the airplane.

### Task 3
Answer:

Inputs that caused crash:
-  S^EO^F^n:^n:fwfwDI# vl ^D+g P < O^F^n:fwfwDI# vl ^D+g P < S^kO  "^FDI

-  SDI# vl ^D+g P <          ttt^F  ^`^@^F^F ^E^F^F^F^F^F^Fvl ^D+g P ^F^A^Fvl ^D+g tt  tttttmt^F^A^W ^D+g P <          f       ttt  tttZttt^F^A^W f ^j6     %>

-  S^S^SSF^Sdf>:KwDI^D+g Pfffl ^D+g P <          Z^kOhhh^hhh q

-  l^E[^F^n:KwDI# vl ^DYg P < S^jOhfffffl^@^@^C ^D+ffhhUhq^k@h

- ffffl ^@^CDI# S^EKwDI# vl ^N+g P < StO "^F^B > ^D+ffq  ^_   P^P^@ S^kDItwt    S^kO "^F^B [ "^F^B >^g@q  # v@q

-  S^EO^F^F+g P <ffffttt4 >^g@^E   ttttt >^g@^V^F^Fl ^D+g ^F^F^F^F+g P <           fffftttt >^g@^E   ttttt >^g@ S^kO

- DI# vl gffffff(^X^Q ^ov~^f^T$_ ^c {^i  ^h 4             ^`^@ ^P l ^A^@lYO=^kOghhfwDI^DKg^h 4            ^`^@ ^P lYghhfwDI# vl ^D+g P < S^kO "^ghhfwDI^Dhhh@q

Description of the inputs that cause the program to crash:
- Any sequence of inputs where the total number of f commands is at least four more than the number of h commands, followed by an l, will cause the program to crash. Based on the fact that the control software is based on the software of exercise2, the reason might be that the initial number of crew members is 4, so if we fire all the crew members, we cannot land the airplane.