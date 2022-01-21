#!/usr/bin/python3
import random
random.seed()
b=[]
i=0
while i<16:
  r=round(random.random()*255)
  b.append(r)
  i+=1
b[6]&=0xf
b[6]^=0x40
b[8]&=0x3f
b[8]^=0x80
out=""
i=0
while i<4:
  out += '%02x' % b[i]
  i+=1
i=0
while i<3:
  f=0
  out+="-"
  while f<2:
    out+= "%02x" % b[i+4+f]
    f+=1
  i+=1
out+="-"
i=10
while i<16:
  out+="%02x" % b[i]
  i+=1
print(out)
