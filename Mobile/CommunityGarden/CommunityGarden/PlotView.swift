//
//  PlotView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import SwiftUI

struct PlotView: View {
    var plot: Plot
    var owner: User
    
    var offset: CGFloat = 20
    
    var body: some View {
        GeometryReader{ reader in
            ZStack {
                secondaryColor
                    .frame(width: reader.size.width - offset)
                    .frame(height: reader.size.height - offset)
                VStack {
                    Spacer()
                    Text(owner.name)
                    AsyncImage(url: owner.profilePicture)
                    Spacer()
                }
            }
        }
       
    }
}
