/*
 * [The "BSD license"]
 *  Copyright (c) 2013 Terence Parr
 *  Copyright (c) 2013 Sam Harwell
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 *  IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 *  OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 *  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 *  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Sharpen;

namespace Antlr4.Runtime.Tree
{
	public class TerminalNodeImpl : TerminalNode
	{
		public Token symbol;

		public RuleNode parent;

		public TerminalNodeImpl(Token symbol)
		{
			this.symbol = symbol;
		}

		public virtual ParseTree GetChild(int i)
		{
			return null;
		}

		public virtual Token GetSymbol()
		{
			return symbol;
		}

		public virtual RuleNode GetParent()
		{
			return parent;
		}

		public virtual Token GetPayload()
		{
			return symbol;
		}

		public virtual Interval GetSourceInterval()
		{
			if (symbol != null)
			{
				int tokenIndex = symbol.GetTokenIndex();
				return new Interval(tokenIndex, tokenIndex);
			}
			return Interval.Invalid;
		}

		public virtual int GetChildCount()
		{
			return 0;
		}

		public virtual T Accept<T, _T1>(ParseTreeVisitor<_T1> visitor) where _T1:T
		{
			return visitor.VisitTerminal(this);
		}

		public virtual string GetText()
		{
			if (symbol != null)
			{
				return symbol.GetText();
			}
			return null;
		}

		public virtual string ToStringTree(Parser parser)
		{
			return ToString();
		}

		public override string ToString()
		{
			if (symbol != null)
			{
				if (symbol.GetType() == Token.Eof)
				{
					return "<EOF>";
				}
				return symbol.GetText();
			}
			else
			{
				return symbol != null ? symbol.ToString() : "<null>";
			}
		}

		public virtual string ToStringTree()
		{
			return ToString();
		}
	}
}