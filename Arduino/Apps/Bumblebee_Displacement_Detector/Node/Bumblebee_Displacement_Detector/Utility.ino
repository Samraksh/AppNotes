
void SerialLLPrint(unsigned long long n, uint8_t base)
{
  unsigned char buf[16 * sizeof(long)]; // Assumes 8-bit chars. 
  unsigned long long i = 0;

  if (n == 0) {
    Serial.print('0');
    return;
  } 

  while (n > 0) {
    buf[i++] = n % base;
    n /= base;
  }

  for (; i > 0; i--)
    Serial.print((char) (buf[i - 1] < 10 ?
      '0' + buf[i - 1] :
      'A' + buf[i - 1] - 10));
}

void SerialLLPrintln(unsigned long long n, uint8_t base) {
	SerialLLPrint(n, base);
	Serial.println();
	}

