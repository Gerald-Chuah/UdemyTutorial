﻿using System;

public class InterfaceSegregation 
{
	//Break larger interface into smaller
	public class Document
	{
	}

	public interface IMachine
	{
		void Print(Document d);
		void Fax(Document d);
		void Scan(Document d);
	}

	// ok if you need a multifunction machine
	public class MultiFunctionPrinter : IMachine
	{
		public void Print(Document d)
		{
			//
		}

		public void Fax(Document d)
		{
			//
		}

		public void Scan(Document d)
		{
			//
		}
	}


	public class OldFashionedPrinter : IMachine
	{
		public void Print(Document d)
		{
			// yep
		}

		//old printer doesnt have these function
		public void Fax(Document d)
		{
			throw new System.NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new System.NotImplementedException();
		}
	}


	//break into smaller parts

	public interface IPrinter
	{
		void Print(Document d);
	}

	public interface IScanner
	{
		void Scan(Document d);
	}

	public interface IFax
	{
		void Fax(Document d);
	}


	public class Printer : IPrinter
	{
		public void Print(Document d)
		{

		}
	}

	public class FaxMachine: IFax, IScanner
	{
		public void Fax(Document d)
		{
			
		}

		public void Scan(Document d)
		{

		}
	}

	public class Photocopier : IPrinter, IScanner
	{
		public void Print(Document d)
		{
			throw new System.NotImplementedException();
		}

		public void Scan(Document d)
		{
			throw new System.NotImplementedException();
		}
	}

	public interface IMultiFunctionDevice : IPrinter, IScanner //
	{

	}

	public struct MultiFunctionMachine : IMultiFunctionDevice
	{
		// compose this out of several modules
		private IPrinter printer;
		private IScanner scanner;

		public MultiFunctionMachine(IPrinter printer, IScanner scanner)
		{
			if (printer == null)
			{
				throw new ArgumentNullException(paramName: Extension.MemberInfoGetting.GetMemberName(()=>printer));
			}
			if (scanner == null)
			{
				throw new ArgumentNullException(paramName: Extension.MemberInfoGetting.GetMemberName(()=>scanner));
			}
			this.printer = printer;
			this.scanner = scanner;
		}

		public void Print(Document d)
		{
			printer.Print(d);
		}

		public void Scan(Document d)
		{
			scanner.Scan(d);
		}
	}



}
