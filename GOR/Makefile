OBJECTS = gor1.o nrutil.o

CFLAGS = -g
LFLAGS = -g -lm

gor: $(OBJECTS)
	cc -o gorIV $(OBJECTS) $(LFLAGS)

clean: 
	rm *.o gorIV

gor1.c: nrutil.h
