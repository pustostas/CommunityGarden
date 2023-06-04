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
                    .clipShape(RoundedRectangle(cornerRadius: 40))
                VStack {
                    Spacer()
                    Text(owner.name)
                    NavigationLink(destination: UserView(user:owner)){
                        AsyncImage(url: owner.profilePicture ) { image in
                                image
                                    .resizable()
                                    .scaledToFit()
                                    .frame(width: reader.size.width - (offset+50), height: reader.size.height - (offset + 50))
                                    .clipShape(Circle())
                                    .overlay {
                                        Circle().stroke(Color.accentColor, lineWidth: 2)
                                    }
                            } placeholder: {
                                ProgressView()
                            }
                            .aspectRatio(3 / 2, contentMode: .fill)
                            .shadow(radius: 4)
                    }
                    Spacer()
                }
            }
        }.clipShape(RoundedRectangle(cornerRadius: 40))
       
    }
}
