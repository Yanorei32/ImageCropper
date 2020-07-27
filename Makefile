CSC		= /cygdrive/c/windows/microsoft.net/framework/v4.0.30319/csc.exe
TARGET	= ImageCropper.exe
SRC		=	src\\Program.cs \
			src\\Form\\MainForm.cs \
			src\\Form\\MainForm.Design.cs \

DEPS	=

CSC_FLAGS		=	/nologo \
					/target:winexe \
					/utf8output

DEBUG_FLAGS		= 
RELEASE_FLAGS	= 

.PHONY: debug
debug: CSC_FLAGS+=$(DEBUG_FLAGS)
debug: all

.PHONY: release
release: CSC_FLAGS+=$(RELEASE_FLAGS)
release: all

.PHONY: genzip
genzip:
	zip -r ImageCropper.zip ImageCropper

all: $(TARGET)
$(TARGET): $(SRC) $(DEPS)
	$(CSC) $(CSC_FLAGS) /out:$(TARGET) $(SRC)

.PHONY: clean
clean:
	rm $(TARGET)


