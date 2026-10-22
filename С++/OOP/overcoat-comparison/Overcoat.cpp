Overcoat::Overcoat()
{
	type = '0';
	cost = 0;
}

void Overcoat::ent()
{
	cout << "Введите брэнд одежды: ";
	gets_s(name);
	cout << "Введите тип одежды (к - куртка и тд.)\n";
	cin >> type;
	cout << "Введите цену\n";
	cin >> cost;
	cin.ignore();
}

void Overcoat::show()
{
	cout << "\nБрэнд: " << name << "\nТип: " << type << "\nЦена: " << cost;
}

Overcoat::Overcoat(const Overcoat& copy)
{
	strcpy_s(name, copy.name);
	type = copy.type;
	cost = copy.cost;
}

Overcoat Overcoat::operator=(const Overcoat& copy)
{
	if (this != &copy)
	{
		strcpy_s(name, copy.name);
		type = copy.type;
		cost = copy.cost;
	}
	return *this;
}

bool operator==(const Overcoat& a, const Overcoat& b)
{
	if (a.type == b.type)
		return true;
}

bool operator>(const Overcoat& a, const Overcoat& b)
{
	if (a.cost > b.cost)
		return true;
	else return false;
}

