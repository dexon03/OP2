class TDate:
    def __init__(self):
        self._day = 0
        self._month = 0
        self._year = 0

    def compare_to(self, date):
        day1 = 0
        month1 = 0
        year1 = 0
        if '.' in date:
            numbers = date.split('.')
            day1 = int(numbers[0])
            month1 = int(numbers[1])
            year1 = int(numbers[2])
        elif '-' in date:
            numbers = date.split('-')
            day1 = int(numbers[1])
            month1 = int(numbers[0])
            year1 = int(numbers[2])
        if self._year < year1 or (
                self._year == year1 and (self._month < month1 or self._month == month1 and (self._day < day1))):
            return -1
        if self._year == year1 and self._month == month1 and self._day == day1:
            return 0
        return 1

    def add_years(self, count):
        if count < 0:
            raise Exception("unvalid value")
        self._year += count

    def add_month(self, count):
        if count < 0:
            raise Exception("unvalid value")
        years = count // 12
        remainder = count % 12
        self._year += years
        self._month += remainder
        if self._month > 12:
            self._year += 1
            self._month -= 12

    def add_days(self, count):
        if count < 0:
            raise Exception("unvalid value")
        years = count // 365
        month_ = count % 365 // 30
        days = (count % 365) % 30
        self._year += years
        self._month += month_
        if self._month > 12:
            self._year += 1
            self._month -= 12
        self._day += days
        if self._day > 30:
            if self._month < 12:
                self._month += 1
            else:
                self._year += 1
            self._day -= 30

    def substract_years(self, count):
        if count < 0:
            raise Exception("unvalid value")
        self._year -= count

    def substract_month(self, count):
        if count < 0:
            raise Exception("unvalid value")
        years = count // 12
        month_ = count % 12
        self._year -= years
        self._month -= month_
        if month_ < 0:
            self._year -= 1
            self._month += 12

    def substract_days(self, count):
        if count < 0:
            raise Exception("unvalid value")
        years = count // 365
        month_ = (count % 365) // 30
        days = (count % 365) % 30
        self._year -= years
        self._month -= month_
        if self._month < 0:
            self._year -= 1
            self._month += 12
        self._day -= days
        if self._day < 30:
            if self._month == 1:
                self._month = 12
                self._year -= 1
            self._day += 30


class TDate1(TDate):
    def __init__(self, date):
        super().__init__()
        numbers = date.split('.')
        self._day = int(numbers[0])
        self._month = int(numbers[1])
        self._year = int(numbers[2])

    def __str__(self):
        return "{0}.{1}.{2}".format(self._day, self._month, self._year)


class TDate2(TDate):
    def __init__(self, date):
        super().__init__()
        numbers = date.split('-')
        self._day = int(numbers[1])
        self._month = int(numbers[0])
        self._year = int(numbers[2])

    def __str__(self):
        return "{0}-{1}-{2}".format(self._month, self._day, self._year)
