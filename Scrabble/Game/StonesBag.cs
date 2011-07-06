//  
//  StonesBag.cs
//  
//  Author:
//       Ondřej Profant <ondrej.profant@gmail.com>
// 
//  Copyright (c) 2011 Ondřej Profant
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;

namespace Scrabble.Game
{
	/// <summary>
	/// Represents bag for game stones.
	/// </summary>
	public class StonesBag
	{
		List<char> content;
		Random rand;
			
		public StonesBag ()
		{
			content = new List<char>( InitialConfig.stones );
			rand = new Random();
		}
		
		public void CompleteRack( List<char> r ) {
			while( r.Count < Scrabble.Game.InitialConfig.sizeOfRack ) {
				try {
					r.Add( getOneStone() );
				} catch {
					break;
				}
			}
		}
		
		public List<char> ReloadAll( List<char> r) {
			List<char> newRack = new List<char>( Scrabble.Game.InitialConfig.sizeOfRack );
			CompleteRack( newRack );
#if DEBUG
			Console.WriteLine("Do vaku vkládám:");
#endif	
			foreach( char c in r) {
				content.Add( c );
#if DEBUG
				Console.Write(c);
#endif
			}
#if DEBUG
			Console.WriteLine();
			Console.WriteLine("Nový rack:");
			foreach(char c in newRack)
				Console.Write(c);
			Console.WriteLine();
#endif
			return newRack;
		}
		
		private char getOneStone() {
			if( content.Count == 0 ) throw new Exception("Empty bag");
			char c = content[ rand.Next(0,content.Count-1) ];
			content.Remove( c );
			return c;
		}
	}
}

